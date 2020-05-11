using System;

namespace TheToolsmiths.Ddl.Parser.Parsers.ParserMaps
{
    internal class ParserMapRegistryBuilder : IParserMapRegistryBuilder
    {
        public ParserMapRegistryBuilder()
        {
            this.RootCategoryBuilder = new ParserMapCategoryBuilder();
        }

        public ParserMapCategoryBuilder RootCategoryBuilder { get; }

        public Type? DefaultParser => this.RootCategoryBuilder.DefaultParser;

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

        public void SetDefaultParser<T>()
            where T : class, IRootItemParser
        {
            this.RootCategoryBuilder.SetDefaultParser<T>();
        }
    }
}
