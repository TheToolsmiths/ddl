using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheToolsmiths.Ddl.Cli.Builders;
using TheToolsmiths.Ddl.Cli.Parsers;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;

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

            IReadOnlyList<AstContentUnit> contentUnits;
            {
                using var scope = serviceProvider.CreateScope();

                var fileParser = scope.ServiceProvider.GetRequiredService<GlobParser>();

                var result = await fileParser.ParseDirectoryGlob(baseDirectory, glob);

                if (result.HasErrors)
                {
                    throw new NotImplementedException();
                }

                contentUnits = result.Contents;
            }

            {
                using var scope = serviceProvider.CreateScope();

                var resolver = scope.ServiceProvider.GetRequiredService<ContentUnitsBuilder>();

                var result = resolver.BuildContentUnits(contentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}
