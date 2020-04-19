using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Shared;

namespace TheToolsmiths.Ddl.Parser.Parsers.ParserMaps
{
    internal class ParserMapCategoryBuilder : IParserMapCategoryBuilder
    {
        public ParserMapCategoryBuilder()
        {
            this.Categories = new Dictionary<string, ParserMapCategoryBuilder>(StringComparer.OrdinalIgnoreCase);
            this.Parsers = new Dictionary<string, Type>();
        }

        public Dictionary<string, ParserMapCategoryBuilder> Categories { get; }

        public Dictionary<string, Type> Parsers { get; }

        public void AddParser<T>(string keyword)
            where T : class, IParser
        {
            this.Parsers.Add(keyword, typeof(T));
        }

        public IParserMapCategoryBuilder AddCategoryParser(string keyword)
        {
            if (this.Categories.TryGetValue(keyword, out var builder))
            {
                return builder;
            }

            builder = new ParserMapCategoryBuilder();

            this.Categories.Add(keyword, builder);

            return builder;
        }
    }
}
