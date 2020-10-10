using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;

namespace TheToolsmiths.Ddl.Writer.Lexer
{
    public class DdlLexerTokenWriter
    {
        public async Task WriteToString(IDdlLexer lexer, PipeWriter outputWriter)
        {
            if (lexer == null)
            {
                throw new ArgumentNullException(nameof(lexer));
            }

            if (outputWriter == null)
            {
                throw new ArgumentNullException(nameof(outputWriter));
            }

            const string lineFeed = "\n";

            using var lineFeedMemoryOwner = MemoryPool<byte>.Shared.Rent(lineFeed.AsSpan().Length);

            var lineFeedMemory = lineFeedMemoryOwner.Memory;

            MemoryMarshal.Cast<char, byte>(lineFeed).CopyTo(lineFeedMemory.Span);

            lineFeedMemory = lineFeedMemory.Slice(0, lineFeed.Length * sizeof(char));

            var arrayBuffer = new ArrayBufferWriter<byte>();

            var encoding = Encoding.UTF8;

            while (true)
            {
                var result = await lexer.TryGetNextToken();

                if (result.IsError)
                {
                    return;
                }

                {
                    var token = result.Token;

                    int byteCount = encoding.GetByteCount(token.Memory.Span);

                    if (byteCount == 0)
                    {
                        continue;
                    }

                    var memory = arrayBuffer.GetMemory(byteCount);

                    int writtenBytes = encoding.GetBytes(token.Memory.Span, memory.Slice(0, byteCount).Span);

                    memory = memory.Slice(0, writtenBytes);

                    await outputWriter.WriteAsync(memory);

                    arrayBuffer.Clear();

                    await outputWriter.WriteAsync(lineFeedMemory);
                }
            }
        }
    }
}
