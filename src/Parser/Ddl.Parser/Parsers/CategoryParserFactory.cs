namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class CategoryParserFactory : ICategoryParserFactory
    {
        public IRootItemParser CreateCategoryParser(IParserMapRegistry registry)
        {
            return new CategoryRootParser(registry);
        }
    }
}
