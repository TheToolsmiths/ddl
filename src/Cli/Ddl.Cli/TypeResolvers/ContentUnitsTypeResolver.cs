using System;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Package.Index;
using TheToolsmiths.Ddl.Parser.TypeResolver;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Cli.TypeResolvers
{
    public class ContentUnitsTypeResolver
    {
        private readonly ILogger<ContentUnitsTypeResolver> log;
        private readonly IDdlContentUnitCollectionTypeResolver resolver;

        public ContentUnitsTypeResolver(
            ILogger<ContentUnitsTypeResolver> log,
            IDdlContentUnitCollectionTypeResolver resolver)
        {
            this.log = log;
            this.resolver = resolver;
        }

        public Result<IReadOnlyList<ContentUnit>> ResolveContentUnitsTypes(
            IReadOnlyList<ContentUnit> contentUnits,
            PackageTypeIndex packageTypeIndex)
        {
            using var _ = this.log.BeginScope("Resolving Content Units Types");

            var result = this.resolver.ResolveCollection(contentUnits, packageTypeIndex);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            this.log.LogInformation("Content Units types resolved");

            return result;
        }
    }
}
