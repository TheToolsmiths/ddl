using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    public class ModelConfigurationProvider : IModelConfigurationProvider
    {
        private readonly ModelConfigurationRegistryBuilder registryBuilder;

        public ModelConfigurationProvider()
        {
            this.registryBuilder = new ModelConfigurationRegistryBuilder();
        }

        public IModelConfigurationRegistryBuilder RegistryBuilder => this.registryBuilder;

        public void Configure(ConfigurationProviderContext context)
        {
            var registrySection = this.registryBuilder.Build();

            context.Services.AddSingleton(registrySection);
        }
    }
}
