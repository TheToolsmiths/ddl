using System;
using System.Collections.Generic;
using Ddl.Common;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Resolve;

namespace TheToolsmiths.Ddl.Cli.Resolvers
{
    public class ContentUnitsResolver
    {
        private readonly ILogger<ContentUnitsResolver> log;
        private readonly IDdlContentUnitCollectionResolver resolver;

        public ContentUnitsResolver(
            ILogger<ContentUnitsResolver> log,
            IDdlContentUnitCollectionResolver resolver)
        {
            this.log = log;
            this.resolver = resolver;
        }

        public Result ResolveContentUnits(IReadOnlyList<ContentUnit> contentUnits)
        {
            using var _ = this.log.BeginScope("Resolve Content Units");

            this.log.BeginScope("Resolving Content Units");

            {
                var result = this.resolver.ResolveContentUnits(contentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            this.log.LogInformation("Content Units resolved");

            return Result.Success;
        }
    }
}
