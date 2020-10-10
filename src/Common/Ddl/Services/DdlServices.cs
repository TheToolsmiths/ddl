using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using TheToolsmiths.Ddl.Parser;

namespace TheToolsmiths.Ddl.Services
{
    public sealed class DdlServices : IAsyncDisposable
    {
        private readonly ServiceProvider serviceProvider;

        private DdlServices(ServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.TextParser = serviceProvider.GetService<DdlTextParser>();
        }

        public DdlTextParser TextParser { get; }

        public static DdlServices Create()
        {
            var services = new ServiceCollection();

            var configurationBuilder = new DdlServicesConfigurationBuilder();

            DdlConfigurationBuilders.RegisterConfigurationBuilders(configurationBuilder);

            RegisterApplicationServices(services);

            DdlConfigurationBuilders.BuildAndRegisterConfiguration(configurationBuilder, services);

            var serviceProvider = services.BuildServiceProvider();

            return new DdlServices(serviceProvider);
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddLogging(
                builder =>
                {
                    builder.ClearProviders();
                    builder.AddConsole();
                });
        }

        public ValueTask DisposeAsync()
        {
            return this.serviceProvider.DisposeAsync();
        }
    }
}
