using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Builders.Wrappers;
using TheToolsmiths.Ddl.Parser.Build.Configurations;
using TheToolsmiths.Ddl.Parser.Configurations;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    internal class RootBuilderResolver
    {
        private readonly IServiceProvider provider;
        private readonly IAstConfigurationSection astConfiguration;

        private RootBuilderResolver(IServiceProvider provider, IAstConfigurationSection astConfiguration)
        {
            this.provider = provider;
            this.astConfiguration = astConfiguration;
        }

        public bool TryResolveItemBuilder(
            IAstRootItem astItem,
            [MaybeNullWhen(false)] out RootItemBuilderWrapper itemBuilder)
        {
            var instanceType = astItem.GetType();
            var itemType = astItem.ItemType;

            if (this.astConfiguration.TryGetTypeValue(itemType, out var builderType))
            {
                var wrapperOpenType = typeof(RootItemBuilderWrapper<,>);

                Type wrapperType = wrapperOpenType.MakeGenericType(builderType, instanceType);

                itemBuilder = (RootItemBuilderWrapper)ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType);

                return itemBuilder != null;
            }

            itemBuilder = default;
            return false;
        }

        public bool TryResolveScopeBuilder(
            IAstRootScope astScope,
            [MaybeNullWhen(false)] out RootScopeBuilderWrapper scopeBuilder)
        {
            var instanceType = astScope.GetType();
            var scopeType = astScope.ScopeType;

            if (this.astConfiguration.TryGetTypeValue(scopeType, out var builderType))
            {
                var wrapperOpenType = typeof(RootScopeBuilderWrapper<,>);

                Type wrapperType = wrapperOpenType.MakeGenericType(builderType, instanceType);

                scopeBuilder = (RootScopeBuilderWrapper)ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType);

                return scopeBuilder != null;
            }

            scopeBuilder = default;
            return false;
        }

        public static RootBuilderResolver CreateResolver(IServiceProvider serviceProvider)
        {
            var astConfigurationRegistry = serviceProvider.GetRequiredService<IAstConfigurationRegistry>();

            if (astConfigurationRegistry.TryGetSection(ConfigurationKeys.BuildConfigurationSection, out var configurationSection) == false)
            {
                throw new NotImplementedException();
            }

            return new RootBuilderResolver(serviceProvider, configurationSection);
        }
    }
}
