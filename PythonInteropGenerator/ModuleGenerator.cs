using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

using Python.Runtime;

namespace PythonInteropGenerator
{
    [Generator]
    public partial class ModuleTypeGenerator : ISourceGenerator
    {
        private readonly static string[] ParentModuleOrPackageNames =
        {
            "__future__",
            "_frozen_importlib_external",
            "_frozen_importlib",
            "_sitebuiltins",
            "abc",
            "builtins",
            "numpy",
            "os",
            "pwnlib",
            "ptrlib",
            "Crypto",
            "typing"
        };
        private readonly static string[] IgnoreModules =
        {
            "numpy.tests",
            "Crypto.SelfTest"
        };

        private PyObject builtins;
        private PyObject inspect;
        private PyObject pkgutil;
        public void Initialize(GeneratorInitializationContext context)
        {
            string PythonDLLPath = $"C:/Users/{Environment.UserName}/AppData/Local/Programs/Python/Python39/python39.dll";
            Runtime.PythonDLL = PythonDLLPath;
            Directory.CreateDirectory(CachePlace);
            using (var gil = Py.GIL())
            {
                builtins = Py.Import("builtins");
                inspect = Py.Import("inspect");
                pkgutil = Py.Import("pkgutil");
            }
        }

        public void Execute(GeneratorExecutionContext context)
        {
            try
            {
                foreach (var name in ParentModuleOrPackageNames)
                {
                    if (!TryGetCodeFromCache(name + ".cs", out string code))
                    {
                        code = $@"using Python.Runtime;
namespace Python.Module
{{
    {GetModuleOrPackageCode(name).Code}
}}";
                        SetCodeToCache(name + ".cs", code);
                    }
                    context.AddSource($"PyModule{name}", SourceText.From(code, Encoding.UTF8));
                }
            }
            catch (Exception e)
            {
                File.WriteAllText(@"C:\Users\keymoon\Desktop\log", e.ToString());
                throw e;
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

        private Py.GILState state = null;
        private bool AcquireGilIfNecessary()
        {
            if (state is null)
            {
                state = Py.GIL();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void FreeGil()
        {
            state.Dispose();
        }
    }

    

    static class CSTypeUtil
    {
        public static string GetTypeName(this Type t)
        {
            if (t == typeof(Dynamic)) return "dynamic";
            if (t.IsGenericType) return $"{t.FullName.Split('`')[0]}<{string.Join(",", t.GetGenericArguments().Select(GetTypeName))}>";
            return t.FullName;
        }
    }

    class Dynamic { }
}
