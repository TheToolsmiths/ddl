using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Indexing.Builders
{
    public class TypeIndexBuilder
    {
        public TypeIndexBuilder()
        {
            this.RootNamespace = new TypeIndexedNamespaceBuilder(string.Empty);
        }

        public TypeIndexedNamespaceBuilder RootNamespace { get; }

        public TypeIndexedNamespaceBuilder GetNamespaceBuilder(RootNamespacePath namespacePath)
        {
            var currentNamespace = this.RootNamespace;

            foreach (string identifier in namespacePath.Identifiers)
            {
                currentNamespace = currentNamespace.GetChildNamespace(identifier);
            }

            return currentNamespace;
        }

        public TypeIndex Build()
        {
            var rootNamespace = this.RootNamespace.Build();

            return new TypeIndex(rootNamespace);
        }
    }
}
