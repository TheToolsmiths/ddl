using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.Package;
using TheToolsmiths.Ddl.Parser.Packager.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Packager
{
    internal class DdlContentUnitCollectionPackager : IDdlContentUnitCollectionPackager
    {
        private readonly DdlContentUnitPackager contentUnitPackager;
        private readonly DdlPackager packager;

        public DdlContentUnitCollectionPackager(DdlContentUnitPackager contentUnitPackager, DdlPackager packager)
        {
            this.contentUnitPackager = contentUnitPackager;
            this.packager = packager;
        }

        public Result<Package> PackageCollection(
            IReadOnlyList<CompiledContentUnit> contentUnits,
            ContentUnitsTypeIndex packageTypeIndex)
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
                var result = this.packager.PackageContentUnits(packedContentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                package = result.Value;
            }

            return Result.FromValue(package);
        }

        public Result<Package> PackageContentUnit(
            CompiledContentUnit contentUnit,
            ContentUnitsTypeIndex packageTypeIndex)
        {
            PackageContentUnit packedContentUnit;
            {
                var result = this.contentUnitPackager.Pack(contentUnit, packageTypeIndex);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                packedContentUnit = result.Value;
            }

            Package package;
            {
                var result = this.packager.PackageContentUnit(packedContentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                package = result.Value;
            }

            return Result.FromValue(package);
        }

        private Result<IReadOnlyList<PackageContentUnit>> PackageContentUnits(
            IReadOnlyList<CompiledContentUnit> contentUnits,
            ContentUnitsTypeIndex packageTypeIndex)
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
    }
}
