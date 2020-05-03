using System;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Parser.Containers;

namespace TheToolsmiths.Ddl.Parser.Parsers.ParserMaps
{
    internal class ParserCategoryRegistry : IParserMapRegistry
    {
        private readonly CharSpanKeyedMap<Type> parsersMap;
        private readonly CharSpanKeyedMap<ParserCategoryRegistry> categoriesMap;


        public ParserCategoryRegistry(
            CharSpanKeyedMap<Type> parsersMap,
            CharSpanKeyedMap<ParserCategoryRegistry> categoriesMap)
        {
            this.parsersMap = parsersMap;
            this.categoriesMap = categoriesMap;
        }

        public bool TryGetParserType(in ReadOnlySpan<char> key, out Type type)
        {
            return this.parsersMap.TryGetValue(key, out type);
        }

        public bool TryGetCategoryRegistry(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out IParserMapRegistry registry)
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
