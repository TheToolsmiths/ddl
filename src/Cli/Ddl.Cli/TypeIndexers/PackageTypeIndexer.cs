using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Package.Index;
using TheToolsmiths.Ddl.Parser.TypeIndexer;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Cli.TypeIndexers
{
    public class PackageTypeIndexer
    {
        private readonly ILogger<PackageTypeIndexer> log;
        private readonly IDdlPackageIndexer indexer;

        public PackageTypeIndexer(
            ILogger<PackageTypeIndexer> log,
            IDdlPackageIndexer indexer)
        {
            this.log = log;
            this.indexer = indexer;
        }

        public Result<PackageTypeIndex> IndexContentUnits(IReadOnlyList<ContentUnit> contentUnits)
        {
            using var _ = this.log.BeginScope("Indexing Content Units");

            var result = this.indexer.IndexCollection(contentUnits);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            this.log.LogInformation("Content Units indexed");

            return result;
        }
    }
}
