using System;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootParserResolver
    {
        bool TryResolveDefaultItemParser([NotNullWhen(true)] out IRootItemParser? itemParser);

        bool TryResolveItemParser(in ReadOnlySpan<char> key, [NotNullWhen(true)] out IRootItemParser? itemParser);

        bool TryResolveScopeParser(in ReadOnlySpan<char> key, [NotNullWhen(true)] out IRootScopeParser? scopeParser);
    }
}
