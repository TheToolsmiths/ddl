﻿using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.ContentUnits
{
    public class ContentUnitIndexedTypes
    {
        public ContentUnitIndexedTypes(
            in ContentUnitId contentUnitId,
            RootNamespacePath contentUnitNamespace,
            ContentUnitIndexedNamespace rootIndexedNamespace)
        {
            this.ContentUnitId = contentUnitId;
            this.ContentUnitNamespace = contentUnitNamespace;
            this.RootIndexedNamespace = rootIndexedNamespace;
        }

        public ContentUnitId ContentUnitId { get; }

        public RootNamespacePath ContentUnitNamespace { get; }

        public ContentUnitIndexedNamespace RootIndexedNamespace { get; }
    }
}
