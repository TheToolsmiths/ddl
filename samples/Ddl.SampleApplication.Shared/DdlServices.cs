using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using TheToolsmiths.Ddl.Parser;
using TheToolsmiths.Ddl.Services;

namespace Ddl.SampleApplication.Shared
{
    public sealed class DdlServices : IAsyncDisposable
    {
        private readonly ServiceProvider serviceProvider;

        private DdlServices(ServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.TextParser = serviceProvider.GetRequiredService<DdlTextParser>();
        }

        public DdlTextParser TextParser { get; }

        public IServiceProvider ServiceProvider => this.serviceProvider;

        public static DdlServices Create()
        {
            var services = new ServiceCollection();

            DdlCommonServices.Register(services);

            RegisterApplicationServices(services);

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
