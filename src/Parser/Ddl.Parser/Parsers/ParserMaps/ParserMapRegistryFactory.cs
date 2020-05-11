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
                var parserProviders = provider.GetServices<IRootParserRegister>();

                foreach (var parserProvider in parserProviders)
                {
                    parserProvider.RegisterParsers(builder);
                }
            }

            var rootCategory = CreateCategory(builder.RootCategoryBuilder);

            return new ParserMapRegistry(rootCategory);
        }

        private static ParserCategoryRegistry CreateCategory(ParserMapCategoryBuilder builder)
        {
            var itemParsersMap = new CharSpanKeyedMap<Type>();
            var scopeParsersMap = new CharSpanKeyedMap<Type>();
            var categoriesMap = new CharSpanKeyedMap<ParserCategoryRegistry>();

            foreach ((string key, var categoryBuilder) in builder.Categories)
            {
                categoriesMap.Add(key, CreateCategory(categoryBuilder));
            }

            foreach ((string key, var parserType) in builder.ItemParsers)
            {
                if (categoriesMap.Contains(key))
                {
                    throw new NotImplementedException();
                }

                itemParsersMap.Add(key, parserType);
            }

            foreach ((string key, var parserType) in builder.ScopeParsers)
            {
                if (categoriesMap.Contains(key))
                {
                    throw new NotImplementedException();
                }
                
                if (itemParsersMap.Contains(key))
                {
                    throw new NotImplementedException();
                }

                scopeParsersMap.Add(key, parserType);
            }

            return new ParserCategoryRegistry(builder.DefaultParser, itemParsersMap, scopeParsersMap, categoriesMap);
        }
    }
}
