using System;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IParserMapCategoryBuilder : IParserMapBuilder
    {
        Type? DefaultParser { get; }

        void SetDefaultParser<T>()
            where T : class, IRootItemParser;
    }
}
