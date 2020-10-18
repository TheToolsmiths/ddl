using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;

namespace TheToolsmiths.Ddl.Models.Build.Indexing.ContentUnits
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
