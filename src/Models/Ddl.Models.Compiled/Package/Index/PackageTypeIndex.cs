using System;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Index;
using TheToolsmiths.Ddl.Models.Compiled.Types.Index;

namespace TheToolsmiths.Ddl.Models.Compiled.Package.Index
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
