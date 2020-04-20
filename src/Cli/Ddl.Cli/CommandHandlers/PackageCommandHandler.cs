using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheToolsmiths.Ddl.Cli.FileParsers;
using TheToolsmiths.Ddl.Cli.Utils;

namespace TheToolsmiths.Ddl.Cli.CommandHandlers
{
    internal static class PackageCommandHandler
    {
        public static void HandlePackageDirectory(
            IHost host,
            DirectoryInfo baseDirectory,
            string glob,
            FileInfo? outputFile)
        {
            var serviceProvider = host.Services;

            throw new NotImplementedException();

            //foreach (var file in FileGlobResolver.ResolveFileGlob(glob, baseDirectory))
            //{
            //    using var scope = serviceProvider.CreateScope();

            //    var inputFile = new FileInfo(Path.Join(baseDirectory.FullName, file.Path));
            //    var outputFile = outputDirectory == null ? null : new FileInfo(Path.Join(outputDirectory.FullName, file.Path));

            //    var fileParser = scope.ServiceProvider.GetService<FileParser>();

            //    fileParser.ParseFromFilePath(inputFile, outputFile, format);
            //}
        }
    }
}
