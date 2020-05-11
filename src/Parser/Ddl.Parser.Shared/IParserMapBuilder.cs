namespace TheToolsmiths.Ddl.Parser
{
    public interface IParserMapBuilder
    {
        IParserMapCategoryBuilder AddCategoryParser(string keyword);

        public void AddItemParser<T>(string keyword)
            where T : class, IRootItemParser;
        
        public void AddScopeParser<T>(string keyword)
            where T : class, IRootScopeParser;
    }
}
