using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    public interface IModelConfigurationProvider : IConfigurationProvider
    {
        IModelConfigurationRegistryBuilder RegistryBuilder { get; }
    }
}
