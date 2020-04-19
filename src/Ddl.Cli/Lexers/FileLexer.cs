using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Cli.Writers;

namespace TheToolsmiths.Ddl.Cli.Lexers
{
    internal class FileLexer
    {
        private readonly ILogger<FileLexer> log;
        private readonly DdlLexerTokenWriter tokenWriter;

        public FileLexer(ILogger<FileLexer> log, DdlLexerTokenWriter tokenWriter)
        {
            this.log = log;
            this.tokenWriter = tokenWriter;
        }

        public void LexerFromFilePath(FileInfo input)
        {
            using var _ = this.log.BeginScope($"Lexing file '{input.FullName}'");

            this.log.BeginScope($"Lexing file '{input}'");

            var pipe = new Pipe();

            var read = Task.Run(async () => await this.LexerFile(input.FullName, pipe.Writer));

            var write = Task.Run(async () => await ConsolePipeWriter.WriteOutputToConsole(pipe.Reader));

            Task.WaitAll(read, write);

            this.log.LogInformation("File lexed");
        }

        private async Task LexerFile(string input, PipeWriter pipeWriter)
        {
            throw new NotImplementedException();

            //var lexer = await this.textLexer.LexerFromFile(input);

            //await this.tokenWriter.WriteToString(lexer, pipeWriter);

            //await pipeWriter.CompleteAsync();
        }
    }
}
