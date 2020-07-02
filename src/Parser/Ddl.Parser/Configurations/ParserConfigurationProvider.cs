﻿using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;
using TheToolsmiths.Ddl.Parser.Parsers.ParserMaps;

namespace TheToolsmiths.Ddl.Parser.Configurations
{
    public class ParserConfigurationProvider : IParserConfigurationProvider
    {
        private readonly ParserMapRegistryBuilder registryBuilder;

        public ParserConfigurationProvider()
        {
            this.registryBuilder = new ParserMapRegistryBuilder();
        }

        public IParserMapRegistryBuilder RegistryBuilder => this.registryBuilder;

        public void Configure(ConfigurationProviderContext context)
        {
            var registry = ParserMapRegistryFactory.CreateMap(this.registryBuilder);

            context.Services.AddSingleton(registry);

            foreach (var itemParserType in ParserMapRegistryFactory.GetItemParserTypeList(this.registryBuilder))
            {
                context.Services.AddTransient(itemParserType);
            }

            foreach (var scopeParserType in ParserMapRegistryFactory.GetScopeParserTypeList(this.registryBuilder))
            {
                context.Services.AddTransient(scopeParserType);
            }
        }
    }
}
