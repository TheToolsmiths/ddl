using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TheToolsmiths.Ddl.Cli.Builders;
using TheToolsmiths.Ddl.Cli.Indexers;
using TheToolsmiths.Ddl.Cli.Parsers;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer;

namespace TheToolsmiths.Ddl.Cli.CommandHandlers
{
    internal static class PackageCommandHandler
    {
        public static async Task HandlePackageDirectory(
            IHost host,
            DirectoryInfo baseDirectory,
            string glob,
            FileInfo? outputFile)
        {
            var serviceProvider = host.Services;

            IReadOnlyList<AstContentUnit> astContentUnits;
            {
                using var scope = serviceProvider.CreateScope();

                var fileParser = scope.ServiceProvider.GetRequiredService<GlobParser>();

                var result = await fileParser.ParseDirectoryGlob(baseDirectory, glob);

                if (result.HasErrors)
                {
                    throw new NotImplementedException();
                }

                astContentUnits = result.Contents;
            }

            IReadOnlyList<ContentUnit> contentUnits;
            {
                using var scope = serviceProvider.CreateScope();

                var resolver = scope.ServiceProvider.GetRequiredService<ContentUnitsBuilder>();

                var result = resolver.BuildContentUnits(astContentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                contentUnits = result.Value;
            }

            PackageIndexedTypes packageIndexedTypes;
            {
                using var scope = serviceProvider.CreateScope();

                var resolver = scope.ServiceProvider.GetRequiredService<ContentUnitsIndexer>();

                var result = resolver.IndexContentUnits(contentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                packageIndexedTypes = result.Value;
            }

            throw new NotImplementedException();
        }
    }
}
