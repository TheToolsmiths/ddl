using System;
using System.Buffers;
using System.Text.Json;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;

namespace Ddl.Transpiler
{
    public static class DdlTranspiler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "Roslyn analysers don't understand await using yet")]
        public static async Task TranspileToString(FileContent content, IBufferWriter<byte> outputWriter)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (outputWriter == null)
            {
                throw new ArgumentNullException(nameof(outputWriter));
            }

            var writerOptions = new JsonWriterOptions { Indented = true };

            await using var writer = new Utf8JsonWriter(outputWriter, writerOptions);

            writer.WriteStartObject();

            writer.WriteStartArray("content");

            foreach (var item in content.Items)
            {
                FileContentTranspiler.WriteFileContentItem(writer, item);
            }

            writer.WriteEndArray();

            writer.WriteEndObject();

            await writer.FlushAsync().ConfigureAwait(false);
        }
    }
}
