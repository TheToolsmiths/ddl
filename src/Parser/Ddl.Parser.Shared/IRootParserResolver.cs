using System;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootParserResolver
    {
        bool TryResolveDefaultItemParser([MaybeNullWhen(false)] out IRootItemParser itemParser);

        bool TryResolveItemParser(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out IRootItemParser itemParser);

        bool TryResolveScopeParser(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out IRootScopeParser scopeParser);
    }
}
