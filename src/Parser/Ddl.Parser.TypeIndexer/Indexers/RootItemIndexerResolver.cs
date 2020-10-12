using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Configurations.Model;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Configurations;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Indexers.Wrappers;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Indexers
{
    internal class RootItemIndexerResolver
    {
        private readonly IServiceProvider provider;
        private readonly IModelConfigurationSection modelConfiguration;

        private RootItemIndexerResolver(IServiceProvider provider, IModelConfigurationSection modelConfiguration)
        {
            this.provider = provider;
            this.modelConfiguration = modelConfiguration;
        }

        public bool TryResolveItemIndexer(
            IRootItem item,
            [NotNullWhen(true)] out RootItemIndexerWrapper? itemIndexer)
        {
            var instanceType = item.GetType();
            var itemType = item.ItemType;

            if (this.modelConfiguration.TryGetTypeValue(itemType, out var builderType))
            {
                Type wrapperType = typeof(RootItemIndexerWrapper<,>).MakeGenericType(builderType, instanceType);

                itemIndexer = ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType) as RootItemIndexerWrapper;

                return itemIndexer != null;
            }

            itemIndexer = default;
            return false;
        }

        public static RootItemIndexerResolver CreateResolver(IServiceProvider serviceProvider)
        {
            var configurationRegistry = serviceProvider.GetRequiredService<IModelConfigurationRegistry>();

            if (configurationRegistry.TryGetSection(ConfigurationKeys.IndexingConfigurationSection, out var configurationSection) == false)
            {
                throw new NotImplementedException();
            }

            return new RootItemIndexerResolver(serviceProvider, configurationSection);
        }
    }
}
