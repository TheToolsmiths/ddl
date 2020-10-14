using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.References.TypeReferences;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Contexts;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class TypeIndexingContext
    {
        public TypeIndexingContext(RootNamespacePath namespacePath)
        {
            this.NamespacePath = namespacePath;

            this.IndexedTypes = new List<EntityTypeReference>();
        }

        public RootNamespacePath NamespacePath { get; }

        public List<EntityTypeReference> IndexedTypes { get; }

        public IRootItemIndexContext CreateItemIndexContext()
        {
            return new RootItemIndexContext();
        }
    }
}
