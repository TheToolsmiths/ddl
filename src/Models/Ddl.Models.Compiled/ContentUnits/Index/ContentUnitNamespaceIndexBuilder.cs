using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Index
{
    public class ContentUnitNamespaceIndexBuilder
    {
        public ContentUnitNamespaceIndexBuilder()
        {
            this.NamespaceMap = new Dictionary<ContentUnitId, RootNamespacePath>();
        }

        public Dictionary<ContentUnitId, RootNamespacePath> NamespaceMap { get; }

        public void AddContentUnitNamespace(in ContentUnitId contentUnitId, RootNamespacePath rootNamespace)
        {
            this.NamespaceMap.Add(contentUnitId, rootNamespace);
        }

        public ContentUnitNamespaceIndex Build()
        {
            return new ContentUnitNamespaceIndex(this.NamespaceMap);
        }
    }
}
