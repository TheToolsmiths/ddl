using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Parser.Configurations
{
    public interface IAstConfigurationProvider : IConfigurationProvider
    {
        IAstConfigurationRegistryBuilder RegistryBuilder { get; }
    }
}
