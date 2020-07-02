using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Parser.ParserMaps;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    internal class RootParserResolver : IRootParserResolver
    {
        private readonly IServiceProvider provider;
        private readonly IParserMapRegistry registry;

        public RootParserResolver(
            IServiceProvider provider,
            IParserMapRegistry registry)
        {
            this.provider = provider;
            this.registry = registry;
        }


        public bool TryResolveScopeParser(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out IRootScopeParser scopeParser)
        {
            if (this.registry.TryGetScopeParserType(key, out var type))
            {
                scopeParser = (IRootScopeParser)this.provider.GetRequiredService(type);

                return scopeParser != null;
            }

            scopeParser = default;
            return false;
        }

        public bool TryResolveDefaultItemParser([MaybeNullWhen(false)] out IRootItemParser itemParser)
        {
            if (this.registry.TryGetDefaultParserType(out var type))
            {
                itemParser = (IRootItemParser)this.provider.GetRequiredService(type);

                return itemParser != null;
            }

            itemParser = default;
            return false;
        }

        public bool TryResolveItemParser(in ReadOnlySpan<char> key, [MaybeNullWhen(false)] out IRootItemParser itemParser)
        {
            if (this.registry.TryGetItemParserType(key, out var type))
            {
                itemParser = (IRootItemParser)this.provider.GetRequiredService(type);

                return itemParser != null;
            }

            if (this.registry.TryGetCategoryRegistry(key, out var category))
            {
                itemParser = this.provider.GetRequiredService<ICategoryParserFactory>().CreateCategoryParser(category);

                return itemParser != null;
            }

            itemParser = default;
            return false;
        }
    }
}
