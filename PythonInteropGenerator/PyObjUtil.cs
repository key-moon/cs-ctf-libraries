using System;
using System.Collections.Generic;
using System.Text;
using Python.Runtime;

namespace PythonInteropGenerator
{
    static class PyObjUtil
    {
        public static string GetFullyQualifiedName(PyObject type)
            => $"{type.GetAttr("__module__")}.{type.GetAttr("__qualname__")}";

        public static IEnumerable<PyType> GetDecorators(PyObject func)
        {
            while (func.HasAttr("__func__"))
            {
                yield return func.GetPythonType() as PyType;
                func = func.GetAttr("__func__");
            }
        }
    }
}
