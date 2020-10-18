using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;

namespace TheToolsmiths.Ddl.Parser.Compiler.Helpers
{
    internal static class NamespaceHelper
    {
        public static QualifiedNamespacePath CreateQualifiedNamespace(RootNamespacePath namespacePath)
        {
            return QualifiedNamespacePath.CreateFromIdentifiers(namespacePath.Identifiers);
        }
    }
}
