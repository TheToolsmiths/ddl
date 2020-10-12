using System;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.ParserMaps
{
    public interface IParserMapRegistry
    {
        bool TryGetDefaultParserType([NotNullWhen(true)] out Type? type);

        bool TryGetItemParserType(in ReadOnlySpan<char> key, [NotNullWhen(true)] out Type? type);

        bool TryGetScopeParserType(in ReadOnlySpan<char> key, [NotNullWhen(true)] out Type? type);

        bool TryGetCategoryRegistry(in ReadOnlySpan<char> key, [NotNullWhen(true)] out IParserMapRegistry? registry);
    }
}
