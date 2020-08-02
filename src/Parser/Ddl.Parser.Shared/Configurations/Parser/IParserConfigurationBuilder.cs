using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;

namespace TheToolsmiths.Ddl.Parser.Configurations.Parser
{
    public interface IParserConfigurationBuilder : IConfigurationBuilder
    {
        IParserMapRegistryBuilder RegistryBuilder { get; }
    }
}
