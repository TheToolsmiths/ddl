using System;

namespace TheToolsmiths.Ddl.Parser.ParserMaps.Builders
{
    public interface IParserMapCategoryBuilder : IParserMapBuilder
    {
        Type? DefaultItemParser { get; }

        void SetDefaultItemParser<T>()
            where T : class, IRootItemParser;
    }
}
