using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Indexing
{
    public class TypeIndex
    {
        public TypeIndex(TypeIndexedNamespace rootNamespace)
        {
            this.RootNamespace = rootNamespace;
        }

        public TypeIndexedNamespace RootNamespace { get; }

        public bool TryGetNamespaceIndex(RootNamespacePath rootNamespace, [NotNullWhen(true)] out TypeIndexedNamespace? indexedNamespace)
        {
            var currentNamespace = this.RootNamespace;
            foreach (string namespaceIdentifier in rootNamespace.Identifiers)
            {
                if (currentNamespace.ChildNamespaces.TryGetValue(namespaceIdentifier, out var childNamespace) == false)
                {
                    indexedNamespace = default;
                    return false;
                }

                currentNamespace = childNamespace;
            }

            indexedNamespace = currentNamespace;
            return true;
        }
    }
}
