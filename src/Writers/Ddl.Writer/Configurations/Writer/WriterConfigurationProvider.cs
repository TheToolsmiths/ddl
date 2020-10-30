using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public class WriterConfigurationProvider : IWriterConfigurationProvider
    {
        private readonly WriterConfigurationRegistryBuilder registryBuilder;

        public WriterConfigurationProvider()
        {
            this.registryBuilder = new WriterConfigurationRegistryBuilder();
        }

        public IWriterConfigurationRegistryBuilder RegistryBuilder => this.registryBuilder;

        public void Configure(ConfigurationProviderContext context)
        {
            var registrySection = this.registryBuilder.Build();

            context.Services.AddSingleton(registrySection);
        }
    }
}
