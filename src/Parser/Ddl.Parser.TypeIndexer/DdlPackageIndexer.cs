﻿using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Build.Indexing.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class DdlPackageIndexer : IDdlPackageIndexer
    {
        private readonly DdlContentUnitNamespaceIndexer contentUnitIndexer;
        private readonly DdlContentUnitTypeIndexer typeIndexer;

        public DdlPackageIndexer(DdlContentUnitTypeIndexer typeIndexer, DdlContentUnitNamespaceIndexer contentUnitIndexer)
        {
            this.typeIndexer = typeIndexer;
            this.contentUnitIndexer = contentUnitIndexer;
        }

        public Result<ContentUnitsTypeIndex> IndexCollection(IReadOnlyList<ContentUnit> contentUnits)
        {
            ContentUnitNamespaceIndex namespaceIndex;
            {
                var result = this.contentUnitIndexer.IndexContentUnits(contentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                namespaceIndex = result.Value;
            }

            TypeIndex typeIndex;
            {
                var result = this.typeIndexer.IndexContentUnits(namespaceIndex, contentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                typeIndex = result.Value;
            }

            var packageIndex = new ContentUnitsTypeIndex(typeIndex, namespaceIndex);

            return Result.FromValue(packageIndex);
        }

        public Result<ContentUnitsTypeIndex> IndexContentUnit(ContentUnit contentUnit)
        {
            ContentUnitNamespaceIndex namespaceIndex;
            {
                var result = this.contentUnitIndexer.IndexContentUnit(contentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                namespaceIndex = result.Value;
            }

            TypeIndex typeIndex;
            {
                var result = this.typeIndexer.IndexContentUnit(namespaceIndex, contentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                typeIndex = result.Value;
            }

            var packageIndex = new ContentUnitsTypeIndex(typeIndex, namespaceIndex);

            return Result.FromValue(packageIndex);
        }
    }
}
