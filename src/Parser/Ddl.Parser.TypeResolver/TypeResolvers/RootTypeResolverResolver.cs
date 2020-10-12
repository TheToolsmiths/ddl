using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Configurations.Model;
using TheToolsmiths.Ddl.Parser.TypeResolver.Common;
using TheToolsmiths.Ddl.Parser.TypeResolver.Configurations;
using TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers.Wrappers;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    internal class RootTypeResolverResolver
    {
        private readonly IServiceProvider provider;
        private readonly IModelConfigurationSection modelConfiguration;

        private RootTypeResolverResolver(IServiceProvider provider, IModelConfigurationSection modelConfiguration)
        {
            this.provider = provider;
            this.modelConfiguration = modelConfiguration;
        }

        public bool TryResolveItemTypeResolver(
            IRootItem item,
            [NotNullWhen(true)] out RootItemTypeResolverWrapper? typeResolver)
        {
            var instanceType = item.GetType();
            var itemType = item.ItemType;

            if (this.modelConfiguration.TryGetTypeValue(itemType, out var builderType))
            {
                if (builderType == typeof(ItemPassthroughTypeResolver))
                {
                    instanceType = typeof(IRootItem);
                }

                var wrapperOpenType = typeof(RootItemTypeResolverWrapper<,>);

                Type wrapperType = wrapperOpenType.MakeGenericType(builderType, instanceType);

                typeResolver = ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType) as RootItemTypeResolverWrapper;

                return typeResolver != null;
            }

            typeResolver = default;
            return false;
        }

        public bool TryResolveScopeTypeResolver(
            IRootScope astScope,
            [NotNullWhen(true)] out RootScopeTypeResolverWrapper? scopeBuilder)
        {
            var instanceType = astScope.GetType();
            var scopeType = astScope.ScopeType;

            if (this.modelConfiguration.TryGetTypeValue(scopeType, out var builderType))
            {
                if (builderType == typeof(ItemPassthroughTypeResolver))
                {
                    instanceType = typeof(IRootScope);
                }

                var wrapperOpenType = typeof(RootScopeTypeResolverWrapper<,>);

                Type wrapperType = wrapperOpenType.MakeGenericType(builderType, instanceType);

                scopeBuilder = ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType) as RootScopeTypeResolverWrapper;

                return scopeBuilder != null;
            }

            scopeBuilder = default;
            return false;
        }

        public static RootTypeResolverResolver CreateResolver(IServiceProvider serviceProvider)
        {
            var astConfigurationRegistry = serviceProvider.GetRequiredService<IModelConfigurationRegistry>();

            if (astConfigurationRegistry.TryGetSection(ConfigurationKeys.ResolveConfigurationSection, out var configurationSection) == false)
            {
                throw new NotImplementedException();
            }

            return new RootTypeResolverResolver(serviceProvider, configurationSection);
        }
    }
}
