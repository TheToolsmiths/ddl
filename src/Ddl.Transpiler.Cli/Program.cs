using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Transpiler.Cli
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await CommandBuilder.CreateCommands()
                .InvokeAsync(args);
        }
    }
}
