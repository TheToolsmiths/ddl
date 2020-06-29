using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;

using TheToolsmiths.Ddl.Parser.Ast.Writer;
using TheToolsmiths.Ddl.Services;
using TheToolsmiths.Ddl.Writer.OutputWriters;

namespace DdlParser
{
    public static class Program
    {
        private const string TestFilePath = "allFeatures.ddl";

        public static void Main()
        {
            var pipe = new Pipe();

            Task.WaitAll(
                Task.Run(() => ParseFile(pipe.Writer)),
                Task.Run(() => WriteOutput(pipe.Reader)));

            Console.WriteLine("Model created");
        }

        private static async Task ParseFile(PipeWriter pipeWriter)
        {
            await using var ddlServices = DdlServices.Create();

            var textParser = ddlServices.TextParser;

            var result = await textParser.ParseFromFile(new FileInfo(TestFilePath)).ConfigureAwait(false);

            if (result.IsSuccess == false
                || result.AstContent == null)
            {
                Console.WriteLine($"Error parsing. Message: '{result.ErrorMessage}'");
            }
            else
            {
                await DdlWriter.Write(result.AstContent, pipeWriter)
                    .ConfigureAwait(false);
            }

            await pipeWriter.CompleteAsync().ConfigureAwait(false);
        }

        private static async Task WriteOutput(PipeReader pipeReader)
        {
            var result = await OutputWriter.WriteToStdOut(pipeReader).ConfigureAwait(false);

            if (result.IsError)
            {
                Console.WriteLine($"Error writing to console: {result.ErrorMessage}");
            }

            await pipeReader.CompleteAsync().ConfigureAwait(false);
        }
    }
}
