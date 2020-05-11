using System;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IParserMapRegistry
    {
        bool TryGetDefaultParserType([MaybeNullWhen(false)]  out Type type);

        bool TryGetItemParserType(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out Type type);
        
        bool TryGetScopeParserType(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out Type type);

        bool TryGetCategoryRegistry(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out IParserMapRegistry registry);
    }
}
