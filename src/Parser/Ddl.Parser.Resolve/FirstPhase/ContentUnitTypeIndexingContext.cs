using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    internal class ContentUnitTypeIndexingContext
    {
        public ContentUnitTypeIndexingContext(NamespacePath namespacePath)
        {
            this.NamespacePath = namespacePath;

            this.IndexedTypes = new List<EntityTypeReference>();
        }

        public NamespacePath NamespacePath { get; }

        public List<EntityTypeReference> IndexedTypes { get; }
    }
}
