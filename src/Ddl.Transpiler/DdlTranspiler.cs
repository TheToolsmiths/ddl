using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;

namespace Ddl.Transpiler
{
    public static class DdlTranspiler
    {
        public static async Task<string> TranspileToString(FileContent content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            await using var stream = new MemoryStream();

            var writerOptions = new JsonWriterOptions { Indented = true };

            await using var writer = new Utf8JsonWriter(stream, writerOptions);

            writer.WriteStartObject();

            writer.WriteStartArray("content");

            foreach (var item in content.Items)
            {
                FileContentTranspiler.WriteFileContentItem(writer, item);
            }

            writer.WriteEndArray();

            writer.WriteEndObject();

            await writer.FlushAsync();

            return Encoding.UTF8.GetString(stream.GetBuffer());
        }
    }
}
