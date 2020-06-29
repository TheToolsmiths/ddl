using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using TheToolsmiths.Ddl.Parser;
using TheToolsmiths.Ddl.Parser.Ast.Writer;
using TheToolsmiths.Ddl.Writer.OutputWriters;

namespace TheToolsmiths.Ddl.Cli.Parsers
{
    internal class FileParser
    {
        private readonly ILogger<FileParser> log;
        private readonly DdlTextParser textParser;

        public FileParser(ILogger<FileParser> log, DdlTextParser textParser)
        {
            this.log = log;
            this.textParser = textParser;
        }

        public void ParseFromFilePath(FileInfo input, FileInfo? output, ParseOutputType format)
        {
            using var _ = this.log.BeginScope($"Parsing file '{input}'");

            var pipe = new Pipe();

            Task.WaitAll(
                this.ParseFile(input, pipe.Writer),
                this.WriteOutput(output, pipe.Reader));

            this.log.LogInformation("File parsed");
        }

        private async Task ParseFile(FileInfo input, PipeWriter pipeWriter)
        {
            // TODO: Migrate to new Ddl.Writer project
            // TODO: Add AST output option to CLI
            throw new NotImplementedException();

            var result = await this.textParser.ParseFromFile(input);

            if (result.IsSuccess
                && result.AstContent != null)
            {
                await DdlWriter.Write(result.AstContent, pipeWriter);
            }
            else
            {
                this.log.LogError("Error parsing '{input}'. Message: '{message}'", input, result.ErrorMessage);
            }

            await pipeWriter.CompleteAsync();
        }

        private async Task WriteOutput(FileInfo? outputFile, PipeReader pipeReader)
        {
            var result = outputFile != null
                ? await OutputWriter.WriteToFile(outputFile, pipeReader)
                : await OutputWriter.WriteToStdOut(pipeReader);

            throw new NotImplementedException();
        }
    }
}
