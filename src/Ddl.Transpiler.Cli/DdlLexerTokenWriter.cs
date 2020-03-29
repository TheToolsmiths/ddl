using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;

namespace TheToolsmiths.Ddl.Transpiler.Cli
{
    public static class DdlLexerTokenWriter
    {
        public static async Task WriteToString(DdlLexer lexer, PipeWriter outputWriter)
        {
            if (lexer == null)
            {
                throw new ArgumentNullException(nameof(lexer));
            }

            if (outputWriter == null)
            {
                throw new ArgumentNullException(nameof(outputWriter));
            }

            string lineFeed = "\r\n";

            using var lineFeedMemoryOwner = MemoryPool<byte>.Shared.Rent(lineFeed.AsSpan().Length);

            var lineFeedMemory = lineFeedMemoryOwner.Memory;

            MemoryMarshal.Cast<char, byte>(lineFeed).CopyTo(lineFeedMemory.Span);

            lineFeedMemory = lineFeedMemory.Slice(0, lineFeed.Length * sizeof(char));

            var arrayBuffer = new ArrayBufferWriter<byte>();

            while (true)
            {
                var result = await lexer.TryGetNextToken();

                if (result.IsError)
                {
                    return;
                }

                var memory = WriteToken(result.Token);

                if (memory.IsEmpty == false)
                {
                    await outputWriter.WriteAsync(memory);

                    await outputWriter.WriteAsync(lineFeedMemory);
                }

                arrayBuffer.Clear();
            }

            Memory<byte> WriteToken(LexerToken token)
            {
                int byteCount = token.Memory.Span.Length * sizeof(char);

                if (byteCount == 0)
                {
                    return Memory<byte>.Empty;
                }

                var memory = arrayBuffer.GetMemory(byteCount);

                var bytes = memory.Slice(0, byteCount).Span;

                MemoryMarshal.Cast<char, byte>(token.Memory.Span).CopyTo(bytes);

                return memory.Slice(0, byteCount);
            }
        }
    }
}
