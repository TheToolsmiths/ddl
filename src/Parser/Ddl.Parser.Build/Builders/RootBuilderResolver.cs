using System;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Builders.Wrappers;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    internal class RootBuilderResolver
    {
        private readonly IServiceProvider provider;
        private readonly IConfigurationRegistry registry;

        public RootBuilderResolver(IServiceProvider provider, IConfigurationRegistry registry)
        {
            this.provider = provider;
            this.registry = registry;
        }

        public bool TryResolveItemBuilder(
            IAstRootItem astItem,
            [MaybeNullWhen(returnValue: false)] out RootItemBuilderWrapper itemBuilder)
        {
            throw new NotImplementedException();

            //var itemType = astItem.GetType();
            //if (this.registry.TryGetItemBuilderType(itemType, out var builderType))
            //{
            //    var wrapperOpenType = typeof(RootItemBuilderWrapper<,>);

            //    Type wrapperType = wrapperOpenType.MakeGenericType(builderType, itemType);

            //    itemBuilder = (RootItemBuilderWrapper)ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType);

            //    return itemBuilder != null;
            //}

            //itemBuilder = default;
            //return false;
        }

        public bool TryResolveScopeBuilder(
            IAstRootScope astScope,
            [MaybeNullWhen(returnValue: false)] out RootScopeBuilderWrapper scopeBuilder)
        {
            throw new NotImplementedException();

            //var scopeType = astScope.GetType();

            //if (this.registry.TryGetScopeBuilderType(scopeType, out var builderType))
            //{
            //    var wrapperOpenType = typeof(RootItemBuilderWrapper<,>);

            //    Type wrapperType = wrapperOpenType.MakeGenericType(builderType, scopeType);

            //    scopeBuilder = (RootScopeBuilderWrapper)ActivatorUtilities.GetServiceOrCreateInstance(this.provider, wrapperType);

            //    return scopeBuilder != null;
            //}

            //scopeBuilder = default;
            //return false;
        }
    }
}
