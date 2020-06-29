using System;
using System.Collections.Generic;
using System.Linq;

using TheToolsmiths.Ddl.Parser.Containers;
using TheToolsmiths.Ddl.Parser.ParserMaps;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;

namespace TheToolsmiths.Ddl.Parser.Parsers.ParserMaps
{
    public static class ParserMapRegistryFactory
    {
        public static IParserMapRegistry CreateMap(ParserMapRegistryBuilder builder)
        {
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

            return new ParserCategoryRegistry(builder.DefaultItemParser, itemParsersMap, scopeParsersMap, categoriesMap);
        }

        public static IReadOnlyList<Type> GetItemParserTypeList(ParserMapRegistryBuilder registryBuilder)
        {
            var types = new List<Type>();

            if (registryBuilder.DefaultItemParser != null)
            {
                types.Add(registryBuilder.DefaultItemParser);
            }

            AddCategoryTypes(registryBuilder.RootCategoryBuilder);

            return types.Distinct().ToList();

            void AddCategoryTypes(ParserMapCategoryBuilder categoryBuilder)
            {
                if (categoryBuilder.DefaultItemParser != null)
                {
                    types.Add(categoryBuilder.DefaultItemParser);
                }

                types.AddRange(categoryBuilder.ItemParsers.Values.ToList());

                foreach (var category in categoryBuilder.Categories.Values)
                {
                    AddCategoryTypes(category);
                }
            }
        }

        public static IReadOnlyList<Type> GetScopeParserTypeList(ParserMapRegistryBuilder registryBuilder)
        {
            var types = new List<Type>();

            AddCategoryTypes(registryBuilder.RootCategoryBuilder);

            return types.Distinct().ToList();

            void AddCategoryTypes(ParserMapCategoryBuilder categoryBuilder)
            {
                types.AddRange(categoryBuilder.ScopeParsers.Values.ToList());

                foreach (var category in categoryBuilder.Categories.Values)
                {
                    AddCategoryTypes(category);
                }
            }
        }
    }
}
