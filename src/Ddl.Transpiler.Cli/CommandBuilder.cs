using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace TheToolsmiths.Ddl.Transpiler.Cli
{
    public static class CommandBuilder
    {
        public static RootCommand CreateCommands()
        {
            var parseCommand = CreateParseCommand();

            var bundleCommand = CreateBundleCommand();

            var rootCommand = new RootCommand { parseCommand, bundleCommand };

            rootCommand.Name = "ddl";
            rootCommand.Description = "TheToolsmiths DDL cli tool";
            return rootCommand;
        }

        private static Symbol CreateParseCommand()
        {
            var parseCommand = new Command("parse")
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

            parseCommand.Description = "Parse the input file into the specified output";


            parseCommand.Handler = CommandHandler.Create<FileInfo, FileInfo, ParseOutputType>(FileParser.ParseFromFilePath);

            return parseCommand;
        }

        private static Symbol CreateBundleCommand()
        {
            var bundleParseCommand = CreateBundleParseCommand();

            var bundleCommand = new Command("bundle")
            {
                bundleParseCommand
            };

            bundleCommand.Description = "Operates on a bundle of files";

            return bundleCommand;
        }

        private static Symbol CreateBundleParseCommand()
        {
            var parseCommand = new Command("parse")
            {
                new Argument<DirectoryInfo>
                {
                    Name = "baseDirectory", Arity = ArgumentArity.ExactlyOne, Description = "Base directory"
                },
                new Argument<string>
                {
                    Name = "glob", Arity = ArgumentArity.ExactlyOne, Description = "Files glob"
                },
                new Option<ParseOutputType>(new[] {"--format", "-f"})
                {
                    Name = "format",
                    Description = "Output format",
                    Argument = new Argument<ParseOutputType>(() => ParseOutputType.Default)
                    {
                        Arity = ArgumentArity.ExactlyOne
                    },
                    Required = false
                },
                new Option<DirectoryInfo>(new[] {"--output", "-o"})
                {
                    Name = "outputDirectory",
                    Description = "Optional output directory",
                    Argument = {
                        Arity = ArgumentArity.ExactlyOne
                    }
                }
            };

            parseCommand.Description = "Parse a bundle of input file into the specified output";

            parseCommand.Handler = CommandHandler
                .Create<DirectoryInfo, string, ParseOutputType, DirectoryInfo?>(
                    BundleFileParser.ParseFromGlob);

            return parseCommand;
        }
    }
}
