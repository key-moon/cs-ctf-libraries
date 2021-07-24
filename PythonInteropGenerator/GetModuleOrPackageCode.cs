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
    public partial class ModuleTypeGenerator
    {
        private ICodeInformation GetModuleOrPackageCode(string fullModuleName, string asName = null)
        {
            if (IgnoreModules.Any(x => fullModuleName.StartsWith(x)))
            {
                return new CommentInformation() { Content = $"module {fullModuleName} skipped due to ignore settings" };
            }

            var moduleName = fullModuleName.Split('.').Last();
            asName ??= moduleName;

            List<string> innerModuleNames;
            List<string> classNames;
            List<string> functionNames;
            List<(string name, string typeName)> nonModuleMembers;

            var acquired = AcquireGilIfNecessary();
            try
            {
                PyObject module;
                try
                {
                    module = Py.Import(fullModuleName);
                }
                catch (PythonException e)
                {
                    return new CommentInformation() { Content = $"\nfailed to import module {fullModuleName}:\n{e}\n" };
                }

                var memberNames = ((PyModule)module).GetDynamicMemberNames().ToArray();

                if (!module.HasAttr("__file__") ||
                    !module.GetAttr("__file__").As<string>().EndsWith("__init__.py"))
                {
                    innerModuleNames = new List<string>();
                }
                else
                {
                    var modulePath = Directory.GetParent(module.GetAttr("__file__").As<string>()).FullName;
                    innerModuleNames =
                        pkgutil.InvokeMethod("iter_modules", new[] { modulePath }.ToPython())
                        .As<PyObject[]>()
                        .Select(x => x.GetAttr("name").As<string>())
                        .Where(x => x != moduleName)
                        .ToList();
                }

                classNames = new List<string>();
                functionNames = new List<string>();
                nonModuleMembers = new List<(string name, string typeName)>();
                foreach (var name in memberNames.Except(innerModuleNames))
                {
                    var val = module.GetAttr(name);

                    var type = PyObjUtil.GetFullyQualifiedName(val.GetPythonType());
                    // class
                    if (type == "builtins.type")
                    {
                        classNames.Add(name);
                        continue;
                    }
                    // function
                    if (type == "builtins.builtin_function_or_method" ||
                        type == "builtins.function" ||
                        type == "builtins.method")
                    {
                        functionNames.Add(name);
                        continue;
                    }
                    // fucking workaround
                    if (type.StartsWith("cffi") ||
                        type == "builtins.module") type = "PyObject";
                    nonModuleMembers.Add((name, type));
                }
            }
            finally
            {
                if (acquired) FreeGil();
            }

            var resolver = new NameContext() { moduleName };

            List<ICodeInformation> infos = new List<ICodeInformation>()
            {
                // prevent from auto-initializing
                new StaticCtorInformation() { ClassName = moduleName, Body = "" },
                // module object
                new DefaultImplementedPropertyInformation()
                {
                    Modifier = "public static",
                    Type = typeof(PyObject),
                    Name = "ModuleObject",
                    Body = "get; set;",
                    DefaultValue = @$"Py.Import(""{fullModuleName}"")"
                }
            };
            infos.AddRange(
                nonModuleMembers.Select(member =>
                    GetVariableCode(
                        "ModuleObject",
                        member.name,
                        member.typeName,
                        resolver.Resolve(member.name)
                    )
                )
            );
            infos.AddRange(
                classNames.Select(
                    name => GetClassCode(fullModuleName, name, resolver.Resolve(name))
                )
            );
            infos.AddRange(
                innerModuleNames.Select(
                    name => GetModuleOrPackageCode($"{fullModuleName}.{name}", resolver.Resolve(name))
                )
            );

            var info = new ClassInformation()
            {
                Modifier = "public static",
                Name = $"@{asName}",
                Body = infos
            };
            return info;
        }
    }
}
