using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    public interface IAstConfigurationProvider : IConfigurationProvider
    {
        IAstConfigurationRegistryBuilder RegistryBuilder { get; }
    }
}
