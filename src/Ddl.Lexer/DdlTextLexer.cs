using System;
using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Lexer
{
    public static class DdlTextLexer
    {
        public static Task<DdlLexer> ParseFromString(string contents)
        {
            throw new NotImplementedException();
        }

        public static Task<DdlLexer> LexerFromFile(string path)
        {
            return Task.Run(async () => await ExecuteParseFromFile(path));
        }

        private static async Task<DdlLexer> ExecuteParseFromFile(string path)
        {
            try
            {
                return await CreateLexer(path);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static async Task<DdlLexer> CreateLexer(string filePath)
        {
            var stream = File.OpenRead(filePath);

            var pipeReader = PipeReader.Create(stream, new StreamPipeReaderOptions(bufferSize: 32));

            var arrayBufferWriter = new ArrayBufferWriter<char>();

            var lexer = new DdlLexer(pipeReader, arrayBufferWriter);

            await lexer.Initialize();

            return lexer;
        }
    }
}
