using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Package;
using TheToolsmiths.Ddl.Models.Build.Package.Index;
using TheToolsmiths.Ddl.Parser.Packager.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Packager
{
    internal class DdlContentUnitCollectionPackager : IDdlContentUnitCollectionPackager
    {
        private readonly DdlContentUnitPackager contentUnitPackager;
        private readonly DdlPackager packager;

        public DdlContentUnitCollectionPackager(
            DdlContentUnitPackager contentUnitPackager,
            DdlPackager packager)
        {
            this.contentUnitPackager = contentUnitPackager;
            this.packager = packager;
        }

        public Result<Package> PackageCollection(IReadOnlyList<ContentUnit> contentUnits, PackageTypeIndex packageTypeIndex)
        {
            IReadOnlyList<PackageContentUnit> packedContentUnits;
            {
                var result = this.PackageContentUnits(contentUnits, packageTypeIndex);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                packedContentUnits = result.Value;
            }

            Package package;
            {
                var result = this.PackContentUnits(packedContentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                package = result.Value;
            }

            return Result.FromValue(package);
        }

        private Result<IReadOnlyList<PackageContentUnit>> PackageContentUnits(IReadOnlyList<ContentUnit> contentUnits, PackageTypeIndex packageTypeIndex)
        {
            var packedContentUnits = new List<PackageContentUnit>();

            foreach (var contentUnit in contentUnits)
            {
                var result = this.contentUnitPackager.Pack(contentUnit, packageTypeIndex);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                packedContentUnits.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<PackageContentUnit>>(packedContentUnits);
        }

        private Result<Package> PackContentUnits(IReadOnlyList<PackageContentUnit> contentUnits)
        {
            var result = this.packager.PackageContentUnits(contentUnits);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return result;
        }
    }
}
