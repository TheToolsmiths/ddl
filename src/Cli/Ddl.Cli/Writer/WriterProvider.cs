using System.IO;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer;

namespace TheToolsmiths.Ddl.Cli.Writer
{
    public class WriterProvider
    {
        private readonly ILogger<WriterProvider> log;
        private readonly IDdlWriterProvider writerProvider;

        public WriterProvider(ILogger<WriterProvider> log, IDdlWriterProvider writerProvider)
        {
            this.log = log;
            this.writerProvider = writerProvider;
        }

        public Result<IWriterHandler> PrepareOutput(FileInfo? outputFile)
        {
            using var _ = this.log.BeginScope("Preparing output");

            IWriterHandler handler;
            if (outputFile != null)
            {
                this.log.LogInformation("Preparing output to file '{file}'", outputFile.Name);

                handler = this.writerProvider.PrepareWriteToFile(outputFile);
            }
            else
            {
                this.log.LogInformation("Preparing output to console");

                handler = this.writerProvider.PrepareWriteToConsole();
            }

            this.log.LogInformation("Output prepared");

            return Result.FromValue(handler);
        }
    }
}
