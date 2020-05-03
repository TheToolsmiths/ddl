using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Cli.Initialization;
using CommandBuilder = TheToolsmiths.Ddl.Cli.Initialization.CommandBuilder;

namespace TheToolsmiths.Ddl.Cli
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            var rootCommand = CommandBuilder.CreateCommands();

            var parser = new CommandLineBuilder(rootCommand)
                .UseDefaults()
                .EnableDirectives()
                .UseVersionOption()
                .UseHelp()
                .UseTranspilerHost()
                .Build();

            return parser.InvokeAsync(args);
        }
    }
}
