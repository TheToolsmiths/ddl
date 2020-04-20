using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

namespace TheToolsmiths.Ddl.Cli.Utils
{
    public static class FileGlobResolver
    {
        public static IEnumerable<FilePatternMatch> ResolveFileGlob(string glob, DirectoryInfo baseDirectory)
        {
            var dirMatcher = new Matcher()
                .AddInclude(glob);

            var directoryInfo = new DirectoryInfoWrapper(baseDirectory);

            var matchingResult = dirMatcher.Execute(directoryInfo);

            return matchingResult.Files;
        }

        public static IEnumerable<FilePatternMatch> ResolveFileGlobForCurrentDirectory(string glob)
        {
            return ResolveFileGlob(glob, new DirectoryInfo(Environment.CurrentDirectory));
        }

        public static IEnumerable<FileInfo> ResolveAbsoluteFilesForCurrentDirectory(string glob)
        {
            return ResolveAbsoluteFiles(glob, new DirectoryInfo(Environment.CurrentDirectory));
        }

        public static IEnumerable<FileInfo> ResolveAbsoluteFiles(string glob, DirectoryInfo baseDirectory)
        {
            return ResolveFileGlob(glob, baseDirectory)
                .Select(match => new FileInfo(Path.Join(baseDirectory.FullName, match.Path)));
        }
    }
}
