using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

using Python.Runtime;

namespace PythonInteropGenerator
{
    [Generator]
    public class ModuleTypeGenerator : ISourceGenerator
    {
        private readonly static string[] ParentModuleOrPackageNames =
        {
            "builtins",
            "numpy",
            "os",
            "pwn",
            "ptrlib",
            "Crypto"
        };
        private readonly static string[] IgnoreModules =
        {
            "numpy.tests",
            "Crypto.SelfTest"
        };

        public void Initialize(GeneratorInitializationContext context)
        {
            try
            {
                string PythonDLLPath = $"C:/Users/{Environment.UserName}/CTF/bin/Python38/python38.dll";
                Runtime.PythonDLL = PythonDLLPath;
                Directory.CreateDirectory(CachePlace);
                // dry run to warm up cache
                foreach (var name in ParentModuleOrPackageNames) GetCode(name);
            }
            catch (Exception e)
            {
                File.WriteAllText(@$"C:\Users\keymoon\Desktop\log\log-{DateTime.Now.Ticks}-init-e", e.ToString());
                throw e;
            }
        }

        public void Execute(GeneratorExecutionContext context)
        {
            foreach (var name in ParentModuleOrPackageNames)
            {
                var code = $@"using Python.Runtime;
namespace Python.Module
{{
    {GetCode(name)}
}}";
                context.AddSource($"PyModule{name}", SourceText.From(code, Encoding.UTF8));
            }
        }

        private readonly static string CachePlace = Path.Combine(Path.GetTempPath(), "PythonNetModuleTypeGeneratorCache");
        private readonly static Dictionary<string, string> OnMemoryCache = new Dictionary<string, string>();
        private string GetCachePath(string fullModuleName) => Path.Combine(CachePlace, fullModuleName);
        private bool TryGetCodeFromCache(string fullModuleName, out string code)
        {
            code = default;

            if (OnMemoryCache.ContainsKey(fullModuleName))
            {
                code = OnMemoryCache[fullModuleName];
                return true;
            }

            var cachePath = GetCachePath(fullModuleName);
            if (File.Exists(GetCachePath(fullModuleName)))
            {
                code = File.ReadAllText(cachePath);
                return true;
            }

            return false;
        }
        private void SetCodeToCache(string fullModuleName, string code)
        {
            OnMemoryCache[fullModuleName] = code;
            File.WriteAllText(GetCachePath(fullModuleName), code);
        }

        private string GetCode(string fullModuleName)
        {
            if (IgnoreModules.Any(x => fullModuleName.StartsWith(x)))
            {
                return $"/* module {fullModuleName} skipped due to ignore settings */";
            }

            File.WriteAllText(@$"C:\Users\keymoon\Desktop\log\log-{DateTime.Now.Ticks}-getcode", fullModuleName);
            if (TryGetCodeFromCache(fullModuleName, out string codeFromCache)) return codeFromCache;

            var moduleName = fullModuleName.Split('.').Last();
            
            string[] importedModuleNames;
            string[] nonModuleMemberNames;
            using (var gil = Py.GIL())
            {
                dynamic module;
                try
                {
                    module = Py.Import(fullModuleName);
                }
                catch (PythonException e)
                {
                    return $"/*\nfailed to import module {fullModuleName}:\n{e}\n*/";
                }

                var memberNames = ((PyModule)module).GetDynamicMemberNames().ToArray();

                if (!module.Contains("__file__") || !((string)module.__file__).EndsWith("__init__.py"))
                {
                    importedModuleNames = Array.Empty<string>();
                }
                else
                {
                    var modulePath = Directory.GetParent((string)module.__file__).FullName;
                    dynamic pkgutil = Py.Import("pkgutil");
                    importedModuleNames =
                        ((PyObject[])pkgutil.iter_modules(new[] { modulePath }))
                        .Select(x => x.GetAttr("name").As<string>())
                        .Where(x => x != moduleName)
                        .ToArray();
                }
                nonModuleMemberNames =
                    memberNames
                    .Except(importedModuleNames)
                    .ToArray();
                File.WriteAllText(@$"C:\Users\keymoon\Desktop\log\log-{DateTime.Now.Ticks}-symbols", $"{fullModuleName}\nnon-modules: {string.Join(", ", nonModuleMemberNames)}\nmodules: {string.Join(", ", moduleName)}");
            }

            var usedNameSet = new HashSet<string>(importedModuleNames.Concat(nonModuleMemberNames));
            string NameFormatter(string name)
            {
                // to avoid conflict with class name
                if (name == moduleName)
                {
                    usedNameSet.Remove(name);
                    do
                    {
                        name += "_";
                    } while (usedNameSet.Contains(name));
                    usedNameSet.Add(name);
                }
                // to avoid conflict with implicit defined method
                if (!name.StartsWith("get_") && !name.StartsWith("set_")) return name;
                usedNameSet.Remove(name);
                while (usedNameSet.Contains(name) || usedNameSet.Contains(name.Substring(4)))
                {
                    name += "_";
                }
                usedNameSet.Add(name);
                return name;
            }

            var code = $@"
public static class {moduleName}
{{
    // prevent from initialize
    static {moduleName}() {{ }}
    public static dynamic ModuleObject = Py.Import(""{fullModuleName}"");
    {string.Join("\n", nonModuleMemberNames.Select(name => $"public static dynamic @{NameFormatter(name)} {{ get => ModuleObject.@{name}; set => ModuleObject.@{name} = value; }}"))}
    {string.Join("\n", importedModuleNames.Select(name => GetCode($"{fullModuleName}.{name}")))}
}}";

            SetCodeToCache(fullModuleName, code);
            return code;
        }
    }
}
