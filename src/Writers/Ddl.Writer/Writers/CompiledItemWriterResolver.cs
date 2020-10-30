using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Writer.Configurations;
using TheToolsmiths.Ddl.Writer.Configurations.Writer;
using TheToolsmiths.Ddl.Writer.Writers.Wrappers;

namespace TheToolsmiths.Ddl.Writer.Writers
{
    internal class CompiledItemDefinitionWriterResolver
    {
        private readonly IServiceProvider provider;
        private readonly IWriterConfigurationSection modelConfiguration;

        private CompiledItemDefinitionWriterResolver(IServiceProvider provider, IWriterConfigurationSection modelConfiguration)
        {
            this.provider = provider;
            this.modelConfiguration = modelConfiguration;
        }

        public bool TryResolveItemDefinitionWriter(
            ICompiledItem item,
            [NotNullWhen(true)] out CompiledItemWriterWrapper? itemWriter)
        {
            var instanceType = item.GetType();
            var itemType = item.ItemType;

            if (this.modelConfiguration.TryGetTypeValue(itemType, out var builderType))
            {
                Type wrapperType = typeof(CompiledItemWriterWrapper<,>).MakeGenericType(builderType, instanceType);

                itemWriter = ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType) as CompiledItemWriterWrapper;

                return itemWriter != null;
            }

            itemWriter = default;
            return false;
        }

        public static CompiledItemDefinitionWriterResolver CreateResolver(IServiceProvider serviceProvider)
        {
            var configurationRegistry = serviceProvider.GetRequiredService<IWriterConfigurationRegistry>();

            if (configurationRegistry.TryGetSection(ConfigurationKeys.DefinitionConfigurationSection, out var configurationSection) == false)
            {
                throw new NotImplementedException();
            }

            return new CompiledItemDefinitionWriterResolver(serviceProvider, configurationSection);
        }
    }
}
