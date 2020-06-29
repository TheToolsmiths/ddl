using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer.OutputWriters
{
    public static class FileOutputWriter
    {
        public static async Task<Result> WriteOutputToFile(FileInfo outputFile, PipeReader pipeReader)
        {
            try
            {
                await HandleWriteOutputToFile(outputFile, pipeReader).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                return Result.FromErrorMessage($"Error writing output. Message: '{e.Message}'");
            }

            return Result.Success;
        }

        private static async Task HandleWriteOutputToFile(FileInfo outputFile, PipeReader pipeReader)
        {
            await using var fileStream = File.OpenWrite(outputFile.FullName);

            await pipeReader.CopyToAsync(fileStream).ConfigureAwait(false);
        }
    }
}
