using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PythonInteropGenerator
{
    class NameContext : IEnumerable<string>
    {
        private HashSet<string> UsedNameSet = new HashSet<string>();
        public NameContext() { }
        public NameContext(IEnumerable<string> UsedNames)
        {
            foreach (var name in UsedNames)
            {
                if (UsedNameSet.Add(name)) continue;
                throw new ArgumentException($"name {name} already exists in context");
            }
        }

        public void Add(string name)
        {
            if (!UsedNameSet.Add(name)) throw new ArgumentException($"name {name} already exists in context");
        }
        public bool Has(string name) => UsedNameSet.Contains(name);
        public void Clear()
        {
            UsedNameSet.Clear();
        }
        public string Resolve(string name)
        {
            while (Has(name)) name += "_";
            Add(name);
            return name;
        }
        public string ResolveProperty(string name)
        {
            while (Has(name) || Has($"get_{name}") || Has($"set_{name}")) name += "_";
            Add(name);
            Add($"get_{name}");
            Add($"set_{name}");
            return name;
        }

        public IEnumerator<string> GetEnumerator() => UsedNameSet.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => UsedNameSet.GetEnumerator();
    }

}
