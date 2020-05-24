using System.Collections.Generic;
using Ddl.Parser.Resolve.Models.Common.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.TypePaths.Namespaces;

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
