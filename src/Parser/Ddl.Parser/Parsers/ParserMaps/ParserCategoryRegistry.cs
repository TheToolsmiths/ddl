using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Parser.Containers;
using TheToolsmiths.Ddl.Parser.Shared;

namespace TheToolsmiths.Ddl.Parser.Parsers.ParserMaps
{
    internal class ParserCategoryRegistry : IParserMapRegistry
    {
        private readonly IServiceProvider provider;
        private readonly CharSpanKeyedMap<Type> parsersMap;
        private readonly CharSpanKeyedMap<ParserCategoryRegistry> categoriesMap;


        public ParserCategoryRegistry(
            IServiceProvider provider,
            CharSpanKeyedMap<Type> parsersMap,
            CharSpanKeyedMap<ParserCategoryRegistry> categoriesMap)
        {
            this.parsersMap = parsersMap;
            this.categoriesMap = categoriesMap;
            this.provider = provider;
        }

        public bool TryGetParser(in ReadOnlySpan<char> key, [MaybeNullWhen(false)]  out IRootItemParser itemParser)
        {
            if (this.parsersMap.TryGetValue(key, out Type type))
            {
                itemParser = this.provider.GetRequiredService(type) as IRootItemParser;

                return itemParser != null;
            }

            if (this.categoriesMap.TryGetValue(key, out var entry))
            {
                itemParser = this.provider.GetRequiredService<ICategoryParserFactory>().CreateCategoryParser(entry);

                return itemParser != null;
            }

            itemParser = default;
            return false;
        }
    }
}
