using System.Collections.Generic;
using Ddl.Resolve.Models.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Namespaces;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    internal class ContentUnitTypeIndexingContext
    {
        public ContentUnitTypeIndexingContext(NamespacePath namespacePath)
        {
            this.NamespacePath = namespacePath;

            this.IndexedTypes = new List<TypePathEntityReference>();
        }

        public NamespacePath NamespacePath { get; }

        public List<TypePathEntityReference> IndexedTypes { get; }
    }
}
