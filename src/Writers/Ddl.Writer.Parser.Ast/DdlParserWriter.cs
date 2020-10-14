using System;
using System.Buffers;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits;

namespace TheToolsmiths.Ddl.Writer.Parser.Ast
{
    public static class DdlParserWriter
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

            //IStructuredWriter writer = new Utf8JsonPipeWriter(outputWriter);

            //writer.WriteStartObject();

            //writer.WriteStartArray("content");

            throw new NotImplementedException();
            //RootScopeWriter.WriteScope(writer, contentUnit.FileRootScope);

            //writer.WriteEndArray();

            //writer.WriteEndObject();

            //await writer.FlushAsync().ConfigureAwait(true);
        }
    }
}
