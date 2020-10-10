using System;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;

using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Output.OutputWriter;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Handlers
{
    internal class DdlWriterWorkHandler
    {
        private async Task<Result> Write(Func<IStructuredContentWriter, Task<Result>> writeContent, IOutputWriter outputWriter)
        {
            var pipe = new Pipe();

            var contentTask = Task.Run(async () => await this.WriteContent(pipe.Writer, writeContent).ConfigureAwait(false));
            var writeTask = Task.Run(async () => await this.WriteOutput(pipe.Reader, outputWriter).ConfigureAwait(false));

            Result[] results;
            try
            {
                results = await Task.WhenAll(contentTask, writeTask).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                return Result.FromException(e);
            }

            if (results.All(r => r.IsSuccess))
            {
                return Result.Success;
            }

            throw new NotImplementedException();
        }

        private async Task<Result> WriteContent(PipeWriter pipeWriter, Func<IStructuredContentWriter, Task<Result>> writeContent)
        {
            //await using var writer = new Utf8JsonPipeWriter(outputWriter);
            await using var structuredWriter = new Utf8JsonPipeWriter(pipeWriter);

            Result result;
            try
            {
                result = await writeContent(structuredWriter).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                result = Result.FromException(e);
            }

            await structuredWriter.FlushAsync().ConfigureAwait(false);

            await pipeWriter.FlushAsync().ConfigureAwait(false);

            await pipeWriter.CompleteAsync().ConfigureAwait(false);

            return result;
        }

        private async Task<Result> WriteOutput(PipeReader pipeReader, IOutputWriter outputWriter)
        {
            Result result;
            try
            {
                result = await outputWriter.WriteAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                result = Result.FromException(e);
            }

            await pipeReader.CompleteAsync().ConfigureAwait(false);

            return result;
        }
    }
}
