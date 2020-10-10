using System.IO;
using System.IO.Pipelines;

using TheToolsmiths.Ddl.Writer.Output;
using TheToolsmiths.Ddl.Writer.Output.OutputWriter;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer
{
#pragma warning disable CA2000 // Dispose objects before losing scope
    internal class DdlWriterProvider : IDdlWriterProvider
    {
        public IWriterHandler PrepareWriteToFile(FileInfo outputFile)
        {
            var pipe = new Pipe();

            var outputWriter = new FileOutputWriter(pipe.Reader, outputFile);

            var contentWriter = new Utf8JsonPipeWriter(pipe.Writer);

            return new WriterHandler(pipe, contentWriter, outputWriter);
        }

        public IWriterHandler PrepareWriteToConsole()
        {
            var pipe = new Pipe();

            var outputWriter = new ConsoleOutputWriter(pipe.Reader);

            var contentWriter = new Utf8JsonPipeWriter(pipe.Writer);

            return new WriterHandler(pipe, contentWriter, outputWriter);
        }
    }
#pragma warning restore CA2000 // Dispose objects before losing scope
}
