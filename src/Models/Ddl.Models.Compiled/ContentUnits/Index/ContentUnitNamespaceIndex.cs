using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Index
{
    public class ContentUnitNamespaceIndex
    {
        private readonly IReadOnlyDictionary<ContentUnitId, RootNamespacePath> namespaceMap;

        public ContentUnitNamespaceIndex(IReadOnlyDictionary<ContentUnitId, RootNamespacePath> contentUnitNamespaceMap)
        {
            this.namespaceMap = contentUnitNamespaceMap;
        }

        public bool TryGetContentUnitNameSpace(
            in ContentUnitId contentUnitId,
            [NotNullWhen(true)] out RootNamespacePath? namespacePath)
        {
            return this.namespaceMap.TryGetValue(contentUnitId, out namespacePath);
        }
    }
}
