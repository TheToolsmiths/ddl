using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    public class AstConfigurationProvider : IAstConfigurationProvider
    {
        private readonly AstConfigurationRegistryBuilder registryBuilder;

        public AstConfigurationProvider()
        {
            this.registryBuilder = new AstConfigurationRegistryBuilder();
        }

        public IAstConfigurationRegistryBuilder RegistryBuilder => this.registryBuilder;

        public void Configure(ConfigurationProviderContext context)
        {
            var registrySection = this.registryBuilder.Build();

            context.Services.AddSingleton(registrySection);
        }
    }
}
