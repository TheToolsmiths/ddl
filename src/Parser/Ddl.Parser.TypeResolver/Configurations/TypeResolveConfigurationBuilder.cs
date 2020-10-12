using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.Configurations.Model;
using TheToolsmiths.Ddl.Parser.TypeResolver.Common;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Configurations
{
    public class TypeResolveConfigurationBuilder : ITypeResolveConfigurationBuilder
    {
        private readonly Dictionary<ItemType, Type> itemTypeResolvers;
        private readonly Dictionary<ScopeType, Type> scopeTypeResolvers;

        public TypeResolveConfigurationBuilder()
        {
            this.itemTypeResolvers = new Dictionary<ItemType, Type>();
            this.scopeTypeResolvers = new Dictionary<ScopeType, Type>();
        }

        public void RegisterTypeResolver<T>(ItemType itemType)
            where T : IItemTypeResolver
        {
            this.itemTypeResolvers.Add(itemType, typeof(T));
        }

        public void RegisterTypeResolver<T>(ScopeType scopeType)
            where T : IScopeTypeResolver
        {
            this.scopeTypeResolvers.Add(scopeType, typeof(T));
        }

        public void RegisterPassthroughTypeResolver(ItemType itemType)
        {
            this.itemTypeResolvers.Add(itemType, typeof(ItemPassthroughTypeResolver));
        }

        public void Configure(ConfigurationBuilderContext context)
        {
            if (context.ProviderCollection.TryGetConfigurationProvider<IModelConfigurationProvider>(out var provider) == false)
            {
                throw new NotImplementedException();
            }

            if (provider.RegistryBuilder.TryGetCategoryBuilder(ConfigurationKeys.ResolveConfigurationSection, out var section) == false)
            {
                throw new NotImplementedException();
            }

            foreach (var (itemType, typeResolverType) in this.itemTypeResolvers)
            {
                section.RegisterTypeValue(itemType, typeResolverType);

                context.Services.AddTransient(typeResolverType);
            }

            foreach (var (scopeType, typeResolverType) in this.scopeTypeResolvers)
            {
                section.RegisterTypeValue(scopeType, typeResolverType);

                context.Services.AddTransient(typeResolverType);
            }
        }
    }
}
