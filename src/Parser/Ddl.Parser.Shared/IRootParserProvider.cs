namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootParserProvider
    {
        void RegisterParsers(IParserMapRegistryBuilder builder);
    }
}
