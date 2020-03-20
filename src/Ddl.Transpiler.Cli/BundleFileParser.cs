using System.IO;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

namespace TheToolsmiths.Ddl.Transpiler.Cli
{
    internal static class BundleFileParser
    {
        public static void ParseFromGlob(
            DirectoryInfo baseDirectory,
            string glob,
            ParseOutputType format,
            DirectoryInfo? outputDirectory)
        {
            var dirMatcher = new Matcher()
                .AddInclude(glob);

            var directoryInfo = new DirectoryInfoWrapper(baseDirectory);

            var matchingResult = dirMatcher.Execute(directoryInfo);

            foreach (var file in matchingResult.Files)
            {
                var filePath = new FileInfo(Path.Join(baseDirectory.FullName, file.Path));

                var outputFile = outputDirectory == null ? null : new FileInfo(Path.Join(outputDirectory.FullName, file.Path));

                FileParser.ParseFromFilePath(filePath, outputFile, format);
            }
        }
    }
}
