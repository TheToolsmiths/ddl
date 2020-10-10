using System;
using System.IO;
using System.Threading.Tasks;

using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Services;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace DdlParser
{
    public static class Program
    {
        private const string TestFilePath = "allFeatures.ddl";

        public static async Task Main()
        {
            throw new NotImplementedException();

            //var workHandler = new DdlWriterWorkHandler();

            //var result = await workHandler.WriteToConsole(async sw => await ParseFile(sw));

            //if (result.IsSuccess)
            //{
            //    Console.WriteLine("Model created");
            //}
        }

        private static async Task<Result> ParseFile(IStructuredContentWriter pipeWriter)
        {
            await using var ddlServices = DdlServices.Create();

            var textParser = ddlServices.TextParser;

            var result = await textParser.ParseFromFile(new FileInfo(TestFilePath)).ConfigureAwait(false);

            //await DdlWriter.Write(result.AstContent, pipeWriter)
            //    .ConfigureAwait(false);

            throw new NotImplementedException();
        }
    }
}
