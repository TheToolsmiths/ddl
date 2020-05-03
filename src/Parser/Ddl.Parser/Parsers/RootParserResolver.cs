using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

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

        public bool TryResolveParser(in ReadOnlySpan<char> key, [MaybeNullWhen(false)]  out IRootItemParser itemParser)
        {
            if (this.registry.TryGetParserType(key, out var type))
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
