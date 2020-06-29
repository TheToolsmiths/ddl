using System;

namespace TheToolsmiths.Ddl.Parser.ParserMaps.Builders
{
    public class ParserMapRegistryBuilder : IParserMapRegistryBuilder
    {
        public ParserMapRegistryBuilder()
        {
            this.RootCategoryBuilder = new ParserMapCategoryBuilder();
        }

        public ParserMapCategoryBuilder RootCategoryBuilder { get; }

        public Type? DefaultItemParser => this.RootCategoryBuilder.DefaultItemParser;

        public IParserMapCategoryBuilder AddCategoryParser(string keyword)
        {
            return this.RootCategoryBuilder.AddCategoryParser(keyword);
        }

        public void AddItemParser<T>(string keyword)
            where T : class, IRootItemParser
        {
            this.RootCategoryBuilder.AddItemParser<T>(keyword);
        }

        public void AddScopeParser<T>(string keyword)
            where T : class, IRootScopeParser
        {
            this.RootCategoryBuilder.AddScopeParser<T>(keyword);
        }

        public void SetDefaultItemParser<T>()
            where T : class, IRootItemParser
        {
            this.RootCategoryBuilder.SetDefaultItemParser<T>();
        }
    }
}
