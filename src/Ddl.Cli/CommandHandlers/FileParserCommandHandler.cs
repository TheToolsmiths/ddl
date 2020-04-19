using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheToolsmiths.Ddl.Cli.FileParsers;

namespace TheToolsmiths.Ddl.Cli.CommandHandlers
{
    internal static class FileParserCommandHandler
    {
        public static void ParseFromFilePathHandler(IHost host, FileInfo input, FileInfo? output, ParseOutputType format)
        {
            var serviceProvider = host.Services;

            using var scope = serviceProvider.CreateScope();

            var fileParser = scope.ServiceProvider.GetService<FileParser>();

            fileParser.ParseFromFilePath(input, output, format);
        }
    }
}
