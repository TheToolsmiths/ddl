using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build.Builders.BuilderMaps
{
    internal class BuilderMapRegistryBuilder : IBuilderMapRegistryBuilder
    {
        private readonly Dictionary<Type, Type> itemBuilderMap = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, Type> scopeBuilderMap = new Dictionary<Type, Type>();

        public IBuilderMapRegistry Build()
        {
            return new BuilderMapRegistry(this.itemBuilderMap, this.scopeBuilderMap);
        }

        public void RegisterItemBuilder<TBuilder, TAstItem>()
            where TBuilder : IRootItemBuilder<TAstItem>
            where TAstItem : class, IAstRootItem
        {
            this.itemBuilderMap.Add(typeof(TAstItem), typeof(TBuilder));
        }

        public void RegisterScopeBuilder<TBuilder, TAstScope>()
            where TBuilder : IRootScopeBuilder<TAstScope>
            where TAstScope : class, IAstRootScope
        {
            this.scopeBuilderMap.Add(typeof(TAstScope), typeof(TBuilder));
        }
    }
}
