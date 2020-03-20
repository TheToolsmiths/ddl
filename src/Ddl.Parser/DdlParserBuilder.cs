using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Parser
{
    public static class DdlParserBuilder
    {
        public static ValueTask<DdlParser> CreateParserForPath(string path)
        {
            var stream = File.OpenRead(path);

            var pipeReader = PipeReader.Create(stream, new StreamPipeReaderOptions(bufferSize: 32));

            return DdlParser.Create(pipeReader);
        }
    }
}
