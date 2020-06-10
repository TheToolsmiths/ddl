using System;
using System.Buffers;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Transpiler
{
    public static class DdlTranspiler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "Roslyn analysers don't understand await using yet")]
        public static async Task TranspileToString(AstContentUnit astContentUnit, IBufferWriter<byte> outputWriter)
        {
            if (astContentUnit == null)
            {
                throw new ArgumentNullException(nameof(astContentUnit));
            }

            if (outputWriter == null)
            {
                throw new ArgumentNullException(nameof(outputWriter));
            }

            var writerOptions = new JsonWriterOptions { Indented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };

            await using var writer = new Utf8JsonWriter(outputWriter, writerOptions);

            writer.WriteStartObject();

            writer.WriteStartArray("content");

            throw new NotImplementedException();

            //foreach (var item in contentUnit.Items)
            //{
            //    FileContentTranspiler.WriteFileContentItem(writer, item);
            //}

            writer.WriteEndArray();

            writer.WriteEndObject();

            await writer.FlushAsync().ConfigureAwait(true);
        }
    }
}
