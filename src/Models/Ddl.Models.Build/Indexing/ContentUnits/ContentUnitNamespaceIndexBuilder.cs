using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Models.Build.Indexing.ContentUnits
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
