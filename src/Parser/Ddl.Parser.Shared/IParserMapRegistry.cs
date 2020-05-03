using System;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IParserMapRegistry
    {
        bool TryGetParserType(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out Type type);
        
        bool TryGetCategoryRegistry(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out IParserMapRegistry registry);
    }
}
