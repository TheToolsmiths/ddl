using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheToolsmiths.Ddl.Cli.Parsers;
using TheToolsmiths.Ddl.Cli.Utils;

namespace TheToolsmiths.Ddl.Cli.CommandHandlers
{
    internal static class BundleFileParserCommandHandler
    {
        public static void HandleParseFromGlob(
            IHost host,
            DirectoryInfo baseDirectory,
            string glob,
            ParseOutputType format,
            DirectoryInfo? outputDirectory)
        {
            var serviceProvider = host.Services;

            foreach (var file in FileGlobResolver.ResolveFileGlob(glob, baseDirectory))
            {
                using var scope = serviceProvider.CreateScope();

                var inputFile = new FileInfo(Path.Join(baseDirectory.FullName, file.Path));
                var outputFile = outputDirectory == null ? null : new FileInfo(Path.Join(outputDirectory.FullName, file.Path));

                var fileParser = scope.ServiceProvider.GetService<FileParser>();

                fileParser.ParseFromFilePath(inputFile, outputFile, format);
            }
        }
    }
}
