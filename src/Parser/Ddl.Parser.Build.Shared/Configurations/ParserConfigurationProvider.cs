using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.Build.BuilderMaps;

namespace TheToolsmiths.Ddl.Parser.Build.Configurations
{
    public class BuilderConfigurationProvider : IConfigurationProvider
    {
        public BuilderConfigurationProvider()
        {
            this.RegistryBuilder = new BuilderMapRegistryBuilder();
        }

        public BuilderMapRegistryBuilder RegistryBuilder { get; }

        public void Configure(ConfigurationProviderContext context)
        {
            // TODO
            //throw new System.NotImplementedException();
        }
    }
}
