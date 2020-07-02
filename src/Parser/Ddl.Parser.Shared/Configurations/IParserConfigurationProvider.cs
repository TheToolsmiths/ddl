using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;

namespace TheToolsmiths.Ddl.Parser.Configurations
{
    public interface IParserConfigurationProvider : IConfigurationProvider
    {
        IParserMapRegistryBuilder RegistryBuilder { get; }
    }
}
