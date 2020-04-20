using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheToolsmiths.Ddl.Cli.FileParsers;

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

            using var scope = serviceProvider.CreateScope();

            var fileParser = scope.ServiceProvider.GetRequiredService<GlobParser>();

            var result = await fileParser.ParseDirectoryGlob(baseDirectory, glob);

            throw new NotImplementedException();
        }
    }
}
