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
        private ICodeInformation GetVariableCode(
            string parentObjectName,
            string objectName,
            string fullyQualifiedTypeName,
            string asName = null
        )
        {
            var acquired = AcquireGilIfNecessary();
            try
            {
                asName ??= fullyQualifiedTypeName.Split('.').Last();
                // should be inhereted from PyObject
                var csTypeName = string.Join(".", fullyQualifiedTypeName.Split('.').Select(x => $"@{x}"));
                return new PropertyInformation()
                {
                    Modifier = "public static",
                    TypeName = csTypeName,
                    Name = $"@{asName}",
                    Body = $@"get => new {csTypeName}({parentObjectName}.GetAttr(""{objectName}"").Handle); set => {parentObjectName}.SetAttr(""{objectName}"", value);"
                };
            }
            finally
            {
                if (acquired) FreeGil();
            }
        }
    }
}
