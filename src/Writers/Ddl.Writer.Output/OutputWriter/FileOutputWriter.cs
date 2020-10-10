using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer.Output.OutputWriter
{
    public class FileOutputWriter : IOutputWriter
    {
        private readonly FileInfo outputFile;
        private readonly PipeReader pipeReader;

        public FileOutputWriter(PipeReader pipeReader, FileInfo outputFile)
        {
            this.outputFile = outputFile;
            this.pipeReader = pipeReader;
        }

        public async Task<Result> WriteAsync()
        {
            try
            {
                await this.HandleWriteOutputToFile().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                return Result.FromErrorMessage($"Error writing output. Message: '{e.Message}'");
            }

            return Result.Success;
        }

        private async Task HandleWriteOutputToFile()
        {
            await using var fileStream = File.OpenWrite(this.outputFile.FullName);

            await this.pipeReader.CopyToAsync(fileStream).ConfigureAwait(false);
        }
    }
}
