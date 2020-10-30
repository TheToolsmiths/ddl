using System;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.Build.Indexing.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Models.Build.Indexing
{
    public class ContentUnitsTypeIndex
    {
        private readonly ContentUnitNamespaceIndex namespaceIndex;
        private readonly TypeIndex typeIndex;

        public ContentUnitsTypeIndex(TypeIndex typeIndex, ContentUnitNamespaceIndex namespaceIndex)
        {
            this.namespaceIndex = namespaceIndex;
            this.typeIndex = typeIndex;
        }

        public bool TryGetContentUnitNamespace(
            in ContentUnitId contentUnitId,
            [NotNullWhen(true)] out TypeIndexedNamespace? indexedNamespace)
        {
            if (this.namespaceIndex.TryGetContentUnitNameSpace(contentUnitId, out var namespacePath) == false)
            {
                throw new NotImplementedException();
            }

            return this.typeIndex.TryGetNamespaceIndex(namespacePath, out indexedNamespace);
        }
    }
}
