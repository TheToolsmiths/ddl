using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer.OutputWriters
{
    public static class OutputWriter
    {
        public static Task<Result> WriteToFile(FileInfo outputFile, PipeReader pipeReader)
        {
            return Task.Run(() => FileOutputWriter.WriteOutputToFile(outputFile, pipeReader));
        }

        public static Task<Result> WriteToStdOut(PipeReader pipeReader)
        {
            return Task.Run(() => ConsoleOutputWriter.WriteOutputToConsole(pipeReader));
        }
    }
}
