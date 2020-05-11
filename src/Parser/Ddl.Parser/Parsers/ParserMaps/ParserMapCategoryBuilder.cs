﻿using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Parsers.ParserMaps
{
    internal class ParserMapCategoryBuilder : IParserMapCategoryBuilder
    {
        public ParserMapCategoryBuilder()
        {
            this.Categories = new Dictionary<string, ParserMapCategoryBuilder>(StringComparer.OrdinalIgnoreCase);
            this.ItemParsers = new Dictionary<string, Type>();
            this.ScopeParsers = new Dictionary<string, Type>();
        }

        public Dictionary<string, ParserMapCategoryBuilder> Categories { get; }

        public Dictionary<string, Type> ItemParsers { get; }

        public Dictionary<string, Type> ScopeParsers { get; }

        public Type? DefaultParser { get; private set; }

        public void AddItemParser<T>(string keyword)
            where T : class, IRootItemParser
        {
            this.ItemParsers.Add(keyword, typeof(T));
        }

        public void AddScopeParser<T>(string keyword)
            where T : class, IRootScopeParser
        {
            this.ScopeParsers.Add(keyword, typeof(T));
        }

        public void SetDefaultParser<T>()
            where T : class, IRootItemParser
        {
            this.DefaultParser = typeof(T);
        }

        public IParserMapCategoryBuilder AddCategoryParser(string keyword)
        {
            if (this.Categories.TryGetValue(keyword, out var builder))
            {
                return builder;
            }

            builder = new ParserMapCategoryBuilder();

            this.Categories.Add(keyword, builder);

            return builder;
        }
    }
}
