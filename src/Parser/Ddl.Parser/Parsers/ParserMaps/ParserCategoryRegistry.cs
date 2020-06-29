using System;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Parser.Containers;
using TheToolsmiths.Ddl.Parser.ParserMaps;

namespace TheToolsmiths.Ddl.Parser.Parsers.ParserMaps
{
    internal class ParserCategoryRegistry : IParserMapRegistry
    {
        private readonly Type? defaultParser;
        private readonly CharSpanKeyedMap<ParserCategoryRegistry> categoriesMap;
        private readonly CharSpanKeyedMap<Type> itemParsersMap;
        private readonly CharSpanKeyedMap<Type> scopeParsersMap;

        public ParserCategoryRegistry(
            Type? defaultParser,
            CharSpanKeyedMap<Type> itemParsersMap,
            CharSpanKeyedMap<Type> scopeParsersMap,
            CharSpanKeyedMap<ParserCategoryRegistry> categoriesMap)
        {
            this.defaultParser = defaultParser;
            this.itemParsersMap = itemParsersMap;
            this.scopeParsersMap = scopeParsersMap;
            this.categoriesMap = categoriesMap;
        }

        public bool TryGetItemParserType(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out Type type)
        {
            return this.itemParsersMap.TryGetValue(key, out type);
        }

        public bool TryGetScopeParserType(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out Type type)
        {
            return this.scopeParsersMap.TryGetValue(key, out type);
        }

        public bool TryGetDefaultParserType([MaybeNullWhen(false)] out Type type)
        {
            type = this.defaultParser;
            return type != null;
        }

        public bool TryGetCategoryRegistry(
            in ReadOnlySpan<char> key,
            [MaybeNullWhen(false)] out IParserMapRegistry registry)
        {
            if (this.categoriesMap.TryGetValue(key, out var categoryRegistry))
            {
                registry = categoryRegistry;
                return true;
            }

            registry = default;
            return false;
        }
    }
}
