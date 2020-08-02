using System;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Build;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Cli.Builders
{
    public class ContentUnitsBuilder
    {
        private readonly ILogger<ContentUnitsBuilder> log;
        private readonly IDdlContentUnitCollectionBuilder builder;

        public ContentUnitsBuilder(
            ILogger<ContentUnitsBuilder> log,
            IDdlContentUnitCollectionBuilder builder)
        {
            this.log = log;
            this.builder = builder;
        }

        public Result<IReadOnlyList<ContentUnit>> BuildContentUnits(IReadOnlyList<AstContentUnit> contentUnits)
        {
            using var _ = this.log.BeginScope("Build Content Units");

            var result = this.builder.BuildCollection(contentUnits);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            this.log.LogInformation("Content Units built");

            return result;
        }
    }
}
