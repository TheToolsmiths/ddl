using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using Microsoft.Extensions.Hosting;
using TheToolsmiths.Ddl.Cli.CommandHandlers;

namespace TheToolsmiths.Ddl.Cli.Initialization
{
    public static class CommandBuilder
    {
        public static RootCommand CreateCommands()
        {
            var lexerCommand = CreateLexerCommand();

            var parseCommand = CreateParseCommand();

            var bundleCommand = CreateBundleCommand();
            
            var packageCommand = CreatePackageCommand();

            var rootCommand = new RootCommand
            {
                new Option(new[] { "--ddlPath"})
                {
                    Name = "ddlPath",
                    Description = "Optional plugin ddl path",
                    Argument = new Argument<FileInfo?>()
                },
                parseCommand,
                bundleCommand,
                lexerCommand,
                packageCommand
            };

            rootCommand.Name = "ddl";
            rootCommand.Description = "TheToolsmiths DDL cli tool";
            return rootCommand;
        }

        private static Symbol CreatePackageCommand()
        {
            var parseCommand = new Command("package")
            {
                new Argument<DirectoryInfo>
                {
                    Name = "baseDirectory", Arity = ArgumentArity.ExactlyOne, Description = "Base directory"
                },
                new Argument<string>
                {
                    Name = "glob", Arity = ArgumentArity.ExactlyOne, Description = "Files glob"
                },
                new Option<FileInfo?>(new[] {"--output", "-o"})
                {
                    Name = "outputFile",
                    Required = false,
                    Description = "Optional output file",
                    Argument = {
                        Arity = ArgumentArity.ExactlyOne
                    }
                }
            };

            parseCommand.Description = "Parse the input file into the specified output";

            parseCommand.Handler = CommandHandler.Create<IHost, DirectoryInfo, string, FileInfo?>(PackageCommandHandler.HandlePackageDirectory);

            return parseCommand;
        }

        private static Symbol CreateLexerCommand()
        {
            var lexerCommand = new Command("lexer")
            {
                new Argument<FileInfo>
                {
                    Name = "input", Arity = ArgumentArity.ExactlyOne, Description = "Input ddl file"
                }
            };

            lexerCommand.Description = "Extracts all Lexer tokens from the input file";

            lexerCommand.Handler = CommandHandler.Create<IHost, FileInfo>(FileLexerCommandHandlers.HandleLexerFromFilePath);

            return lexerCommand;
        }

        private static Symbol CreateParseCommand()
        {
            var parseCommand = new Command("parse")
            {
                new Argument<FileInfo>
                {
                    Name = "input", Arity = ArgumentArity.ExactlyOne, Description = "Input ddl file"
                },
                new Option(new[] {"--output", "-o"})
                {
                    Name = "output",
                    Description = "Optional output file",
                    Argument = new Argument<FileInfo?>()
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
                }
            };

            parseCommand.Description = "Parse the input file into the specified output";

            parseCommand.Handler = CommandHandler.Create<IHost, FileInfo, FileInfo?, ParseOutputType>(FileParserCommandHandler.ParseFromFilePathHandler);

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
                .Create<IHost, DirectoryInfo, string, ParseOutputType, DirectoryInfo?>(
                    BundleFileParserCommandHandler.HandleParseFromGlob);

            return parseCommand;
        }
    }
}
