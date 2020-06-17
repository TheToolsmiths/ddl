using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.TypeResolution
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
