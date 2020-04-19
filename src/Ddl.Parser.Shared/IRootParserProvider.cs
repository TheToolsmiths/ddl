namespace TheToolsmiths.Ddl.Parser.Shared
{
    public interface IRootParserProvider
    {
        void RegisterParsers(IParserMapRegistryBuilder builder);
    }
}
