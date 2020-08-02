using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Configurations.Model;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Configurations;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Indexers.Wrappers;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Indexers
{
    internal class RootIndexerResolver
    {
        private readonly IServiceProvider provider;
        private readonly IModelConfigurationSection modelConfiguration;

        private RootIndexerResolver(IServiceProvider provider, IModelConfigurationSection modelConfiguration)
        {
            this.provider = provider;
            this.modelConfiguration = modelConfiguration;
        }

        public bool TryResolveItemBuilder(
            IRootItem item,
            [MaybeNullWhen(false)] out RootItemIndexerWrapper itemBuilder)
        {
            var instanceType = item.GetType();
            var itemType = item.ItemType;

            if (this.modelConfiguration.TryGetTypeValue(itemType, out var builderType))
            {
                var wrapperOpenType = typeof(RootItemIndexerWrapper<,>);

                Type wrapperType = wrapperOpenType.MakeGenericType(builderType, instanceType);

                itemBuilder = (RootItemIndexerWrapper)ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType);

                return itemBuilder != null;
            }

            itemBuilder = default;
            return false;
        }

        public static RootIndexerResolver CreateResolver(IServiceProvider serviceProvider)
        {
            var astConfigurationRegistry = serviceProvider.GetRequiredService<IModelConfigurationRegistry>();

            if (astConfigurationRegistry.TryGetSection(ConfigurationKeys.IndexingConfigurationSection, out var configurationSection) == false)
            {
                throw new NotImplementedException();
            }

            return new RootIndexerResolver(serviceProvider, configurationSection);
        }
    }
}
