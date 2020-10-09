using System;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Index;
using TheToolsmiths.Ddl.Models.Types.Index;

namespace TheToolsmiths.Ddl.Models.Package.Index
{
    public class PackageTypeIndex
    {
        private readonly ContentUnitNamespaceIndex namespaceIndex;
        private readonly TypeIndex typeIndex;

        public PackageTypeIndex(TypeIndex typeIndex, ContentUnitNamespaceIndex namespaceIndex)
        {
            this.namespaceIndex = namespaceIndex;
            this.typeIndex = typeIndex;
        }

        public bool TryGetContentUnitNamespace(
            in ContentUnitId contentUnitId,
            [NotNullWhen(returnValue: true)] out TypeIndexedNamespace? indexedNamespace)
        {
            if (this.namespaceIndex.TryGetContentUnitNameSpace(contentUnitId, out var namespacePath) == false)
            {
                throw new NotImplementedException();
            }

            return this.typeIndex.TryGetNamespaceIndex(namespacePath, out indexedNamespace);
        }
    }
}
