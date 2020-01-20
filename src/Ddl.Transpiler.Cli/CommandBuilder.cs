using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace TheToolsmiths.Ddl.Transpiler.Cli
{
    public static class CommandBuilder
    {
        public static RootCommand CreateCommands()
        {
            var transpileCommand = new Command("parse")
            {
                new Argument<FileInfo>
                {
                    Name = "input", Arity = ArgumentArity.ExactlyOne, Description = "Input ddl file"
                },
                new Option(new[] {"--format", "-f"})
                {
                    Name = "format",
                    Description = "Output format",
                    Argument = new Argument<ParseOutputType>(() => ParseOutputType.Default)
                    {
                        Arity = ArgumentArity.ExactlyOne
                    },
                    Required = false
                },
                new Option(new[] {"--output", "-o"})
                {
                    Name = "output",
                    Description = "Optional output file",
                    Argument = new Argument<FileInfo>()
                }
            };

            transpileCommand.Description = "Parse the input file into the specified output";

            transpileCommand.Handler = CommandHandler.Create<FileInfo, FileInfo, ParseOutputType?>(FileParser.ParseFromFilePath);

            var rootCommand = new RootCommand { transpileCommand };

            rootCommand.Name = "ddl";
            rootCommand.Description = "TheToolsmith's ddl cli tool";
            return rootCommand;
        }
    }
}
