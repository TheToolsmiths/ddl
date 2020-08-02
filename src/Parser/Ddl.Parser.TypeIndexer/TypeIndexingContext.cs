using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Contexts;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class TypeIndexingContext
    {
        public TypeIndexingContext(NamespacePath namespacePath)
        {
            this.NamespacePath = namespacePath;

            this.IndexedTypes = new List<EntityTypeReference>();
        }

        public NamespacePath NamespacePath { get; }

        public List<EntityTypeReference> IndexedTypes { get; }

        public IRootItemIndexContext CreateItemIndexContext()
        {
            return new RootItemIndexContext();
        }
    }
}
