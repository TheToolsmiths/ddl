using System;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.Package;
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
            IReadOnlyList<CompiledContentUnit> contentUnits,
            ContentUnitsTypeIndex contentUnitsTypeIndex)
        {
            using var _ = this.log.BeginScope("Packaging Content Units");

            var result = this.collectionPackager.PackageCollection(contentUnits, contentUnitsTypeIndex);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            this.log.LogInformation("Content Units packaged");

            return result;
        }
    }
}
