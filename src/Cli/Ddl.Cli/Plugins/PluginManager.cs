using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace TheToolsmiths.Ddl.Cli.Plugins
{
    internal class PluginManager :  IPluginManager, IHostedService
    {
        private readonly PluginManagerConfiguration configuration;

        public PluginManager(IOptions<PluginManagerConfiguration> options)
        {
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}
