using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheToolsmiths.Ddl.Cli.Lexers;

namespace TheToolsmiths.Ddl.Cli.CommandHandlers
{
    internal static class FileLexerCommandHandlers
    {
        public static void HandleLexerFromFilePath(IHost host, FileInfo input)
        {
            var serviceProvider = host.Services;
            using var scope = serviceProvider.CreateScope();

            scope.ServiceProvider.GetService<FileLexer>().LexerFromFilePath(input);
        }
    }
}
