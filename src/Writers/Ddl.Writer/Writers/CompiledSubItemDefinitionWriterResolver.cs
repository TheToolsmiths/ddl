using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Writer.Configurations;
using TheToolsmiths.Ddl.Writer.Configurations.Writer;
using TheToolsmiths.Ddl.Writer.Writers.Wrappers;

namespace TheToolsmiths.Ddl.Writer.Writers
{
    internal class CompiledSubItemDefinitionWriterResolver
    {
        private readonly IServiceProvider provider;
        private readonly IWriterConfigurationSection modelConfiguration;

        private CompiledSubItemDefinitionWriterResolver(IServiceProvider provider, IWriterConfigurationSection modelConfiguration)
        {
            this.provider = provider;
            this.modelConfiguration = modelConfiguration;
        }

        public bool TryResolveSubItemDefinitionWriter(
            ICompiledSubItem item,
            [NotNullWhen(true)] out CompiledSubItemWriterWrapper? subItemWriter)
        {
            var instanceType = item.GetType();
            var subItemType = item.SubItemType;

            if (this.modelConfiguration.TryGetTypeValue(subItemType, out var builderType))
            {
                Type wrapperType = typeof(CompiledSubItemWriterWrapper<,>).MakeGenericType(builderType, instanceType);

                subItemWriter = ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType) as CompiledSubItemWriterWrapper;

                return subItemWriter != null;
            }

            subItemWriter = default;
            return false;
        }

        public static CompiledSubItemDefinitionWriterResolver CreateResolver(IServiceProvider serviceProvider)
        {
            var configurationRegistry = serviceProvider.GetRequiredService<IWriterConfigurationRegistry>();

            if (configurationRegistry.TryGetSection(ConfigurationKeys.DefinitionConfigurationSection, out var configurationSection) == false)
            {
                throw new NotImplementedException();
            }

            return new CompiledSubItemDefinitionWriterResolver(serviceProvider, configurationSection);
        }
    }
}
