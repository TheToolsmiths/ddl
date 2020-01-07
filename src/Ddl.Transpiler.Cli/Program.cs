using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;
using Ddl.Transpiler;
using TheToolsmiths.Ddl.Parser;

namespace TheToolsmiths.Ddl.Transpiler.Cli
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var transpileCommand = new Command("transpile")
            {
                new Argument<FileInfo>
                {
                    Name = "input", Arity = ArgumentArity.ExactlyOne, Description = "Input ddl file"
                },
                new Option(new[] {"--output", "-o"})
                {
                    Name = "output", Description = "Optional output json file", Argument = new Argument<FileInfo>()
                }
            };

            transpileCommand.Handler = CommandHandler.Create<FileInfo, FileInfo>(TranspileFromFilePath);

            var rootCommand = new RootCommand
            {
                transpileCommand
            };

            rootCommand.Name = "ddl";
            rootCommand.Description = "ddl cli tool";

            await rootCommand.InvokeAsync(args);
        }

        private static async Task TranspileFromFilePath(FileInfo input, FileInfo? output)
        {
            var contents = await DdlTextParser.ReadFromFile(input.FullName);

            if (output != null)
            {
                throw new ArgumentException(nameof(output));
            }

            string result = await DdlTranspiler.TranspileToString(contents);

            Console.Write(result);
        }
    }
}
