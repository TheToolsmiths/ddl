using System;
using System.Buffers;
using System.Threading.Tasks;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Ast.Writer.Writers;
using TheToolsmiths.Ddl.Writer.StructuredWriters;

namespace TheToolsmiths.Ddl.Parser.Ast.Writer
{
    public static class DdlWriter
    {
        public static async Task Write(AstContentUnit contentUnit, IBufferWriter<byte> outputWriter)
        {
            if (contentUnit == null)
            {
                throw new ArgumentNullException(nameof(contentUnit));
            }

            if (outputWriter == null)
            {
                throw new ArgumentNullException(nameof(outputWriter));
            }

            IStructuredWriter writer = new Utf8JsonPipeWriter(outputWriter);

            writer.WriteStartObject();

            writer.WriteStartArray("content");

            throw new NotImplementedException();
            //RootScopeWriter.WriteScope(writer, contentUnit.FileRootScope);

            writer.WriteEndArray();

            writer.WriteEndObject();

            await writer.FlushAsync().ConfigureAwait(true);
        }
    }
}
