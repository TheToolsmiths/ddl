using System;
using System.Buffers;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer
{
    public static class DdlContentUnitWriter
    {
        public static async Task Write(ContentUnit contentUnit, IBufferWriter<byte> outputWriter)
        {
            if (contentUnit == null)
            {
                throw new ArgumentNullException(nameof(contentUnit));
            }

            if (outputWriter == null)
            {
                throw new ArgumentNullException(nameof(outputWriter));
            }

            await using var writer = new StructuredTextPipeWriter(outputWriter);
            //await using var writer = new Utf8JsonPipeWriter(outputWriter);

            writer.WriteStartObject();

            writer.WritePropertyName("content");

            throw new NotImplementedException();

            //ScopeContentWriter.WriteScopeContent(writer, contentUnit.CompiledScope.Content);

            writer.WriteEndObject();

            await writer.FlushAsync().ConfigureAwait(true);
        }
    }
}
