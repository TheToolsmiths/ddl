using System;
using System.Buffers;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;
using TheToolsmiths.Ddl.Writer.Writer.Scopes;

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

            ScopeContentWriter.WriteScopeContent(writer, contentUnit.RootScope.Content);

            writer.WriteEndObject();

            await writer.FlushAsync().ConfigureAwait(true);
        }
    }
}
