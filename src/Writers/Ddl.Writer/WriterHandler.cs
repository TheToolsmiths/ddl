using System;
using System.IO.Pipelines;
using System.Threading.Tasks;

using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Output.OutputWriter;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer
{
    internal class WriterHandler : IWriterHandler
    {
        private readonly IStructuredContentWriter contentWriter;
        private readonly IOutputWriter outputWriter;
        private readonly Pipe pipe;

        public WriterHandler(Pipe pipe, IStructuredContentWriter contentWriter, IOutputWriter outputWriter)
        {
            this.pipe = pipe;
            this.contentWriter = contentWriter;
            this.outputWriter = outputWriter;
        }

        public async Task<Result> WriteOutputAsync()
        {
            var result = await this.outputWriter.WriteAsync().ConfigureAwait(false);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            await this.pipe.Reader.CompleteAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<Result> WriteContent<TContext>(Func<IStructuredContentWriter, TContext, Task<Result>> contentWriterFunc, TContext context)
        {
            var writer = this.contentWriter;

            var result = await contentWriterFunc(writer, context).ConfigureAwait(false);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            await this.contentWriter.FlushAsync().ConfigureAwait(false);

            await this.pipe.Writer.CompleteAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<Result> WriteContent(Func<IStructuredContentWriter, Task<Result>> contentWriterFunc)
        {
            var writer = this.contentWriter;

            var result = await contentWriterFunc(writer).ConfigureAwait(false);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            await this.contentWriter.FlushAsync().ConfigureAwait(false);

            await this.pipe.Writer.CompleteAsync().ConfigureAwait(false);

            return result;
        }

        public async ValueTask DisposeAsync()
        {
            await this.contentWriter.DisposeAsync().ConfigureAwait(false);
        }
    }
}
