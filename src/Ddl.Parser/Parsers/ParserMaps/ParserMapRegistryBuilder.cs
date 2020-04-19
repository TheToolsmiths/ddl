using TheToolsmiths.Ddl.Parser.Shared;

namespace TheToolsmiths.Ddl.Parser.Parsers.ParserMaps
{
    internal class ParserMapRegistryBuilder : IParserMapRegistryBuilder
    {
        public ParserMapRegistryBuilder()
        {
            this.RootCategoryBuilder = new ParserMapCategoryBuilder();
        }

        public ParserMapCategoryBuilder RootCategoryBuilder { get; }

        public IParserMapCategoryBuilder AddCategoryParser(string keyword)
        {
            return this.RootCategoryBuilder.AddCategoryParser(keyword);
        }

        public void AddParser<T>(string keyword)
            where T : class, IParser
        {
            this.RootCategoryBuilder.AddParser<T>(keyword);
        }
    }
}
