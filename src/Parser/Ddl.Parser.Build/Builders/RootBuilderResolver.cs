using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Builders.Wrappers;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    internal class RootBuilderResolver
    {
        private readonly IServiceProvider provider;
        private readonly IBuilderMapRegistry registry;

        public RootBuilderResolver(IServiceProvider provider, IBuilderMapRegistry registry)
        {
            this.provider = provider;
            this.registry = registry;
        }

        public bool TryResolveItemBuilder(
            IAstRootItem astItem,
            [MaybeNullWhen(returnValue: false)] out IRootItemBuilderWrapper itemBuilder)
        {
            var itemType = astItem.GetType();
            if (this.registry.TryGetItemBuilderType(itemType, out var builderType))
            {
                var wrapperOpenType = typeof(RootItemBuilderWrapper<,>);

                Type wrapperType = wrapperOpenType.MakeGenericType(builderType, itemType);

                itemBuilder = (IRootItemBuilderWrapper)ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType);

                return itemBuilder != null;
            }

            itemBuilder = default;
            return false;
        }

        public bool TryResolveScopeBuilder(
            IAstRootScope astScope,
            [MaybeNullWhen(returnValue: false)] out IRootScopeBuilderWrapper scopeBuilder)
        {
            var scopeType = astScope.GetType();

            if (this.registry.TryGetScopeBuilderType(scopeType, out var builderType))
            {
                var wrapperOpenType = typeof(RootItemBuilderWrapper<,>);

                Type wrapperType = wrapperOpenType.MakeGenericType(builderType, scopeType);

                scopeBuilder = (IRootScopeBuilderWrapper)ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType);

                return scopeBuilder != null;
            }

            scopeBuilder = default;
            return false;
        }
    }
}
