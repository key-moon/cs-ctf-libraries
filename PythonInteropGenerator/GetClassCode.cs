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
        private ICodeInformation GetClassCode(string fullModuleName, string className, string asName = null)
        {
            asName ??= className.Split('.').Last();
            var acquired = AcquireGilIfNecessary();
            try
            {

            }
            finally
            {
                if (acquired) FreeGil();
            }

            List<ICodeInformation> infos = new List<ICodeInformation>()
            {
                // necessary for inheritance
                new CtorInformation()
                {
                    Modifier = "public",
                    ClassName = $"@{asName}",
                    Arguments = new[] { (typeof(IntPtr), "ptr") },
                    Initializer = "base(ptr)",
                    Body = ""
                },
            };

            var info = new ClassInformation()
            {
                Modifier = "public",
                Inheritances = new[] { typeof(PyObject) },
                Name = $"@{asName}",
                Body = infos
            };
            return info;
        }
    }
}
