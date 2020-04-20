using System;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IParserMapRegistry
    {
        bool TryGetParser(in ReadOnlySpan<char> key, out IRootItemParser itemParser);
    }
}
