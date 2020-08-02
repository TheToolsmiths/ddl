using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    public static class PackageIndexedTypesBuilder
    {
        public static PackageIndexedTypes Build(IReadOnlyList<ContentUnitIndexedTypes> indexedTypes)
        {
            // TODO: Index and build the indexed types collection
            // I'm skipping implementation for now since the actual indexing usage isn't clear yet

            return new PackageIndexedTypes();
        }
    }
}
