using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.Configurations.Model;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Configurations
{
    public class IndexingConfigurationBuilder : IIndexingConfigurationBuilder
    {
        private readonly Dictionary<ItemType, Type> itemIndexers;

        public IndexingConfigurationBuilder()
        {
            this.itemIndexers = new Dictionary<ItemType, Type>();
        }
        public void RegisterItemIndexer<T>(ItemType itemType)
            where T : IRootItemIndexer
        {
            this.itemIndexers.Add(itemType, typeof(T));
        }

        public void Configure(ConfigurationBuilderContext context)
        {
            if (context.ProviderCollection.TryGetConfigurationProvider<IModelConfigurationProvider>(out var provider) == false)
            {
                throw new NotImplementedException();
            }

            if (provider.RegistryBuilder.TryGetCategoryBuilder(ConfigurationKeys.IndexingConfigurationSection, out var section) == false)
            {
                throw new NotImplementedException();
            }

            foreach (var (itemType, builderType) in this.itemIndexers)
            {
                section.RegisterTypeValue(itemType, builderType);

                context.Services.AddTransient(builderType);
            }
        }
    }
}
