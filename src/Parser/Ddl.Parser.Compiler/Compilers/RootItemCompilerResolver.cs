using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Parser.Compiler.Compilers.Wrappers;
using TheToolsmiths.Ddl.Parser.Compiler.Configurations;
using TheToolsmiths.Ddl.Parser.Configurations.Model;

namespace TheToolsmiths.Ddl.Parser.Compiler.Compilers
{
    internal class RootItemCompilerResolver
    {
        private readonly IServiceProvider provider;
        private readonly IModelConfigurationSection modelConfiguration;

        private RootItemCompilerResolver(IServiceProvider provider, IModelConfigurationSection modelConfiguration)
        {
            this.provider = provider;
            this.modelConfiguration = modelConfiguration;
        }

        public bool TryResolveItemCompiler(
            IRootItem item,
            [NotNullWhen(true)] out RootItemCompilerWrapper? itemCompiler)
        {
            var instanceType = item.GetType();
            var itemType = item.ItemType;

            if (this.modelConfiguration.TryGetTypeValue(itemType, out var builderType))
            {
                var wrapperOpenType = typeof(RootItemCompilerWrapper<,>);

                Type wrapperType = wrapperOpenType.MakeGenericType(builderType, instanceType);

                itemCompiler = ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType) as RootItemCompilerWrapper;

                return itemCompiler != null;
            }

            itemCompiler = default;
            return false;
        }

        public bool TryResolveScopeCompiler(
            IRootScope scope,
            [NotNullWhen(true)] out RootScopeCompilerWrapper? scopeCompiler)
        {
            var instanceType = scope.GetType();
            var scopeType = scope.ScopeType;

            if (this.modelConfiguration.TryGetTypeValue(scopeType, out var builderType))
            {
                var wrapperOpenType = typeof(RootScopeCompilerWrapper<,>);

                Type wrapperType = wrapperOpenType.MakeGenericType(builderType, instanceType);

                scopeCompiler = ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType) as RootScopeCompilerWrapper;

                return scopeCompiler != null;
            }

            scopeCompiler = default;
            return false;
        }

        public static RootItemCompilerResolver CreateResolver(IServiceProvider serviceProvider)
        {
            var astConfigurationRegistry = serviceProvider.GetRequiredService<IModelConfigurationRegistry>();

            if (astConfigurationRegistry.TryGetSection(ConfigurationKeys.ResolveConfigurationSection, out var configurationSection) == false)
            {
                throw new NotImplementedException();
            }

            return new RootItemCompilerResolver(serviceProvider, configurationSection);
        }
    }
}
