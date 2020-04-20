using System;
using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Cli.Writers;
using TheToolsmiths.Ddl.Parser;
using TheToolsmiths.Ddl.Transpiler;

namespace TheToolsmiths.Ddl.Cli.FileParsers
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

            this.log.BeginScope($"Parsing file '{input}'");

            var pipe = new Pipe();

            Task.WaitAll(
                this.ParseFile(input, pipe.Writer),
                this.WriteOutput(output, pipe.Reader));

            this.log.LogInformation("File parsed");
        }

        private async Task ParseFile(FileInfo input, PipeWriter pipeWriter)
        {
            var result = await this.textParser.ParseFromFile(input.FullName);

            if (result.IsSuccess
                && result.Value != null)
            {
                await DdlTranspiler.TranspileToString(result.Value, pipeWriter);
            }
            else
            {
                this.log.LogError("Error parsing '{input}'. Message: '{message}'", input, result.ErrorMessage);
            }

            await pipeWriter.CompleteAsync();
        }

        private async Task WriteOutput(FileInfo? output, PipeReader pipeReader)
        {
            try
            {
                if (output == null)
                {
                    await ConsolePipeWriter.WriteOutputToConsole(pipeReader);
                    return;
                }

                await this.WriteOutputToFile(output, pipeReader);
                return;
            }
            catch (Exception e)
            {
                this.log.LogError("Error writing output. Message: '{message}'", e);

                await pipeReader.CompleteAsync();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "Roslyn analysers don't understand await using yet")]
        private async Task WriteOutputToFile(FileInfo output, PipeReader pipeReader)
        {
            await using var fileStream = File.OpenWrite(output.FullName);

            await pipeReader.CopyToAsync(fileStream);
        }
    }
}
