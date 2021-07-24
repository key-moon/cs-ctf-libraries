using System;
using System.Linq;
using System.Collections.Generic;

namespace PythonInteropGenerator
{
    interface ICodeInformation
    {
        public string Code { get; }
    }
    interface ICodeWithNameInformation : ICodeInformation
    {
        public string Name { get; }
    }
    class CommentInformation : ICodeInformation
    {
        public string Content { get; set; }
        public string Code => $"/* {Content.Replace("*/", "* /")} */";
    }
    class RawCodeInformation : ICodeInformation
    {
        public string Code { get; set; }
    }
    class DocCommentInformation : ICodeInformation
    {
        // TODO
        public string Xml => "";
        public string Code => string.Join("\n", Xml.Split('\n').Select(x => "///" + x));
    }
    class NameSpaceInformation : ICodeWithNameInformation
    {
        public string Name { get; set; }
        public IList<ICodeInformation> Body { get; set; } = Array.Empty<ICodeInformation>();
        public string Code => $@"namespace {Name}
{{
{string.Join("\n", Body.Select(x => x.Code))}
}}";
    }
    class CtorInformation : ICodeInformation
    {
        public string Modifier { get; set; }
        public string ClassName { get; set; }
        public string Body { get; set; }
        public string Initializer { get; set; } = default;
        public IList<(Type type, string name)> Arguments { get; set; } = Array.Empty<(Type, string)>();

        public string Code => $@"{Modifier} {ClassName}({string.Join(",", Arguments.Select(x => $"{x.type.GetTypeName()} {x.name}"))}) {(Initializer is null ? "" : $" : {Initializer}")}
{{
{Body}
}}";
    }
    class StaticCtorInformation : ICodeInformation
    {
        public string ClassName { get; set; }
        public string Body { get; set; }
        public string Code => $@"static {ClassName}() {{ {Body} }}";
    }
    class FunctionInformation : ICodeWithNameInformation
    {
        public DocCommentInformation Document { get; set; } = new DocCommentInformation();
        public string Modifier { get; set; }
        public string Name { get; set; }
        public Type ReturnType { get; set; }
        public IList<(Type type, string name)> Arguments { get; set; } = Array.Empty<(Type, string)>();
        public string Body { get; set; }

        public string Code => $@"{Document.Code}
{Modifier} {ReturnType.GetTypeName()} {Name}({string.Join(",", Arguments.Select(x => $"{x.type.GetTypeName()} {x.name}"))})
{{
{Body}
}}";
    }
    class ClassInformation : ICodeWithNameInformation
    {
        public DocCommentInformation Document { get; set; } = new DocCommentInformation();
        public string Modifier { get; set; }
        public string Name { get; set; }
        public IList<ICodeInformation> Body { get; set; } = Array.Empty<ICodeInformation>();
        public IList<Type> Inheritances { get; set; } = Array.Empty<Type>();
        public string Code => $@"{Modifier} class {Name} {(Inheritances.Count == 0 ? "" : $" : {string.Join(", ", Inheritances.Select(x => x.GetTypeName()))}")}
{{
{string.Join("\n", Body.Select(x => x.Code))}
}}";
    }
    class PropertyInformation : ICodeInformation
    {
        public DocCommentInformation Document { get; set; } = new DocCommentInformation();
        public string Modifier { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public string TypeName { get; set; }
        public string Body { get; set; }

        public string Code => $@"{Document.Code}
{Modifier} {Type?.GetTypeName() ?? TypeName} {Name}
{{
{Body}
}}";
    }
    class DefaultImplementedPropertyInformation : ICodeInformation
    {
        public DocCommentInformation Document { get; set; } = new DocCommentInformation();
        public string Modifier { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public string Body { get; set; }
        public string DefaultValue { get; set; }

        public string Code => $@"{Document.Code}
{Modifier} {Type.FullName} {Name} {{ {Body} }} = {DefaultValue};";
    }
}
