using System;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Parser.Containers;

namespace TheToolsmiths.Ddl.Parser.Parsers.ParserMaps
{
    public static class ParserMapRegistryFactory
    {
        public static IParserMapRegistry CreateMap(IServiceProvider provider)
        {
            var builder = new ParserMapRegistryBuilder();

            using (var _ = provider.CreateScope())
            {
                var parserProviders = provider.GetServices<IRootParserProvider>();

                foreach (var parserProvider in parserProviders)
                {
                    parserProvider.RegisterParsers(builder);
                }
            }

            var rootCategory = CreateCategory(provider, builder.RootCategoryBuilder);

            return new ParserMapRegistry(rootCategory);
        }

        private static ParserCategoryRegistry CreateCategory(
            IServiceProvider provider,
            ParserMapCategoryBuilder builder)
        {
            var parsersMap = new CharSpanKeyedMap<Type>();
            var categoriesMap = new CharSpanKeyedMap<ParserCategoryRegistry>();

            foreach ((string key, var categoryBuilder) in builder.Categories)
            {
                categoriesMap.Add(key, CreateCategory(provider, categoryBuilder));
            }

            foreach ((string key, var parserType) in builder.Parsers)
            {
                if (categoriesMap.Contains(key))
                {
                    throw new NotImplementedException();
                }

                parsersMap.Add(key, parserType);
            }

            return new ParserCategoryRegistry(provider, parsersMap, categoriesMap);
        }
    }
}
