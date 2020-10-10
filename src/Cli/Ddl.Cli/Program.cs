using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Diagnostics;
using System.Threading.Tasks;

using TheToolsmiths.Ddl.Cli.Initialization;

using CommandBuilder = TheToolsmiths.Ddl.Cli.Initialization.CommandBuilder;

namespace TheToolsmiths.Ddl.Cli
{
    public static class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();

            var rootCommand = CommandBuilder.CreateCommands();

            var parser = new CommandLineBuilder(rootCommand)
                .UseDefaults()
                .EnableDirectives()
                .UseVersionOption()
                .UseHelp()
                .UseDdlHost()
                .Build();

            int result = await parser.InvokeAsync(args);

            timer.Stop();

            return result;
        }
    }
}
