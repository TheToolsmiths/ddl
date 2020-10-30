using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public class DefinitionWriterConfigurationBuilder : ConfigurationBuilder, IDefinitionWriterConfigurationBuilder
    {
        private readonly Dictionary<ItemType, Type> itemWriters;
        private readonly Dictionary<SubItemType, Type> subItemWriters;

        public DefinitionWriterConfigurationBuilder()
        {
            this.itemWriters = new Dictionary<ItemType, Type>();
            this.subItemWriters = new Dictionary<SubItemType, Type>();
        }

        public void RegisterItemWriter<T>(ItemType itemType)
            where T : ICompiledItemWriter
        {
            this.itemWriters.Add(itemType, typeof(T));
        }

        public void RegisterSubItemWriter<T>(SubItemType subItemType)
            where T : ICompiledSubItemWriter
        {
            this.subItemWriters.Add(subItemType, typeof(T));
        }

        public override void Configure(ConfigurationBuilderContext context)
        {
            if (context.ProviderCollection.TryGetConfigurationProvider<IWriterConfigurationProvider>(out var provider) == false)
            {
                throw new NotImplementedException();
            }

            if (provider.RegistryBuilder.TryGetCategoryBuilder(ConfigurationKeys.DefinitionConfigurationSection, out var section) == false)
            {
                throw new NotImplementedException();
            }

            foreach (var (itemType, builderType) in this.itemWriters)
            {
                section.RegisterTypeValue(itemType, builderType);

                context.Services.AddTransient(builderType);
            }

            foreach (var (subItemType, builderType) in this.subItemWriters)
            {
                section.RegisterTypeValue(subItemType, builderType);

                context.Services.AddTransient(builderType);
            }
        }
    }
}
