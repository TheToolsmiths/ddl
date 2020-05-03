using System;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootParserResolver
    {
        bool TryResolveParser(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out IRootItemParser itemParser);
    }
}
