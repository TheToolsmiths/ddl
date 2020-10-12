using System;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Package;
using TheToolsmiths.Ddl.Models.Package.Index;
using TheToolsmiths.Ddl.Parser.Packager;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Cli.Packagers
{
    public class ContentUnitsPackager
    {
        private readonly ILogger log;
        private readonly IDdlContentUnitCollectionPackager collectionPackager;

        public ContentUnitsPackager(
            ILogger<ContentUnitsPackager> log,
            IDdlContentUnitCollectionPackager collectionPackager)
        {
            this.log = log;
            this.collectionPackager = collectionPackager;
        }

        public Result<Package> PackageContentUnits(
            IReadOnlyList<ContentUnit> contentUnits,
            PackageTypeIndex packageTypeIndex)
        {
            using var _ = this.log.BeginScope("Packaging Content Units");

            var result = this.collectionPackager.PackageCollection(contentUnits, packageTypeIndex);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            this.log.LogInformation("Content Units packaged");

            return result;
        }
    }
}
