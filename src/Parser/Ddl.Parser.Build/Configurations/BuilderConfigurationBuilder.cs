using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.Configurations.Ast;

namespace TheToolsmiths.Ddl.Parser.Build.Configurations
{
    public class BuilderConfigurationBuilder : IBuilderConfigurationBuilder
    {
        private readonly Dictionary<AstItemType, Type> itemBuilders;
        private readonly Dictionary<AstScopeType, Type> scopeBuilders;

        public BuilderConfigurationBuilder()
        {
            this.itemBuilders = new Dictionary<AstItemType, Type>();
            this.scopeBuilders = new Dictionary<AstScopeType, Type>();
        }
        public void RegisterItemBuilder<T>(AstItemType itemType)
        {
            this.itemBuilders.Add(itemType, typeof(T));
        }

        public void RegisterScopeBuilder<T>(AstScopeType scopeType)
        {
            this.scopeBuilders.Add(scopeType, typeof(T));
        }

        public void Configure(ConfigurationBuilderContext context)
        {
            if (context.ProviderCollection.TryGetConfigurationProvider<IAstConfigurationProvider>(out var provider) == false)
            {
                throw new NotImplementedException();
            }

            if (provider.RegistryBuilder.TryGetCategoryBuilder(ConfigurationKeys.BuildConfigurationSection, out var section) == false)
            {
                throw new NotImplementedException();
            }

            foreach (var (itemType, builderType) in this.itemBuilders)
            {
                section.RegisterTypeValue(itemType, builderType);

                context.Services.AddTransient(builderType);
            }

            foreach (var (scopeType, builderType) in this.scopeBuilders)
            {
                section.RegisterTypeValue(scopeType, builderType);

                context.Services.AddTransient(builderType);
            }
        }
    }
}
