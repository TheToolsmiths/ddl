using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using TheToolsmiths.Ddl.Parser;
using TheToolsmiths.Ddl.Parser.Configurations;

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

            configurationBuilder.ConfigurationRegistryBuilder
                .AddProvider<IParserConfigurationProvider, ParserConfigurationProvider>()
                .AddProvider<IAstConfigurationProvider, AstConfigurationProvider>();

            configurationBuilder.ParserConfigurators
                .AddConfigurator<Parser.Build.Implementations.Plugins.ParserConfigurator>()
                .AddConfigurator<Parser.Implementations.Plugins.ParserConfigurator>();

            var servicesRegister = new DdlServicesRegister(services);

            RegisterApplicationServices(services);

            var providers = configurationBuilder.ParserConfigurators.Build();
            var providerCollection = configurationBuilder.ConfigurationRegistryBuilder.Build();

            servicesRegister.RegisterServices(providers, providerCollection);

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
