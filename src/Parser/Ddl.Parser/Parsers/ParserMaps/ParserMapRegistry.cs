using System;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Parser.ParserMaps;

namespace TheToolsmiths.Ddl.Parser.Parsers.ParserMaps
{
    internal class ParserMapRegistry : IParserMapRegistry
    {
        private readonly ParserCategoryRegistry rootRegistry;

        public ParserMapRegistry(ParserCategoryRegistry rootRegistry)
        {
            this.rootRegistry = rootRegistry;
        }

        public bool TryGetItemParserType(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out Type type)
        {
            return this.rootRegistry.TryGetItemParserType(key, out type);
        }

        public bool TryGetScopeParserType(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out Type type)
        {
            return this.rootRegistry.TryGetScopeParserType(key, out type);
        }

        public bool TryGetDefaultParserType([MaybeNullWhen(false)] out Type type)
        {
            return this.rootRegistry.TryGetDefaultParserType(out type);
        }

        public bool TryGetCategoryRegistry(
            in ReadOnlySpan<char> key,
            [MaybeNullWhen(false)] out IParserMapRegistry registry)
        {
            return this.rootRegistry.TryGetCategoryRegistry(key, out registry);
        }
    }
}
