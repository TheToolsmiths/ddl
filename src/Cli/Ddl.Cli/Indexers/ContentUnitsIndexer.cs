using System;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Cli.Indexers
{
    public class ContentUnitsIndexer
    {
        private readonly ILogger<ContentUnitsIndexer> log;
        private readonly IDdlContentUnitCollectionIndexer indexer;

        public ContentUnitsIndexer(
            ILogger<ContentUnitsIndexer> log,
            IDdlContentUnitCollectionIndexer indexer)
        {
            this.log = log;
            this.indexer = indexer;
        }

        public Result<PackageIndexedTypes> IndexContentUnits(IReadOnlyList<ContentUnit> contentUnits)
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
