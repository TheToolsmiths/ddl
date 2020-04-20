namespace TheToolsmiths.Ddl.Parser.Shared
{
    public interface IParserMapBuilder
    {
        IParserMapCategoryBuilder AddCategoryParser(string keyword);

        public void AddParser<T>(string keyword)
            where T : class, IParser;
    }
}
