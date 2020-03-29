using System;
using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;

namespace TheToolsmiths.Ddl.Transpiler.Cli
{
    internal static class FileLexer
    {
        public static void LexerFromFilePath(FileInfo input)
        {
            Console.WriteLine();
            Console.WriteLine($"Lexing file '{input.FullName}'");

            var pipe = new Pipe();

            var read = Task.Run(async () => await LexerFile(input, pipe.Writer));

            var write = Task.Run(async () => await WriteOutput(pipe.Reader));

            Task.WaitAll(read, write);

            Console.WriteLine("File lexed");
            Console.WriteLine();
        }

        private static async Task LexerFile(FileInfo input, PipeWriter pipeWriter)
        {
            var lexer = await DdlTextLexer.LexerFromFile(input.FullName);

            await DdlLexerTokenWriter.WriteToString(lexer, pipeWriter);

            await pipeWriter.CompleteAsync();
        }

        private static async Task WriteOutput(PipeReader pipeReader)
        {
            var decoder = Encoding.Unicode.GetDecoder();
            var bufferWriter = new ArrayBufferWriter<char>();

            void ProcessLine(ReadOnlySequence<byte> slice)
            {
                foreach (var charBytes in slice)
                {
                    int byteCharCount = decoder.GetCharCount(charBytes.Span, false);

                    var charSpan = bufferWriter.GetSpan(byteCharCount);

                    int writtenChars = decoder.GetChars(charBytes.Span, charSpan, false);

                    string s = charSpan.Slice(0, writtenChars).ToString();

                    Console.Write(s);
                }
            }

            while (true)
            {
                var result = await pipeReader.ReadAsync();

                var buffer = result.Buffer;

                ProcessLine(buffer);

                // Tell the PipeReader how much of the buffer we have consumed
                pipeReader.AdvanceTo(buffer.End);

                // Stop reading if there's no more data coming
                if (result.IsCompleted)
                {
                    break;
                }
            }

            // Mark the PipeReader as complete
            pipeReader.Complete();
        }
    }
}
