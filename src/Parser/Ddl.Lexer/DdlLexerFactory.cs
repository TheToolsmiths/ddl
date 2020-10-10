using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace TheToolsmiths.Ddl.Lexer
{
    internal class DdlLexerFactory : IDdlLexerFactory
    {
        private readonly ILoggerFactory loggerFactory;

        public DdlLexerFactory(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        public async Task<IDdlLexer> CreateForFile(string path)
        {
            var stream = File.OpenRead(path);

            var pipeReader = PipeReader.Create(stream, new StreamPipeReaderOptions(minimumReadSize: 32));

            var log = this.loggerFactory.CreateLogger<DdlLexer>();

            var lexer = new DdlLexer(log, pipeReader);

            await lexer.Initialize().ConfigureAwait(false);

            return lexer;
        }
    }
}
