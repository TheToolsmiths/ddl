using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Build.BuilderMaps
{
    public class BuilderMapRegistryBuilder : IBuilderMapRegistryBuilder
    {
        private readonly Dictionary<ItemType, Type> itemBuilders;
        private readonly Dictionary<ScopeType, Type> scopeBuilders;

        public BuilderMapRegistryBuilder()
        {
            this.itemBuilders = new Dictionary<ItemType, Type>();
            this.scopeBuilders = new Dictionary<ScopeType, Type>();
        }

        public void RegisterItemBuilder<TBuilder>(ItemType itemType)
            where TBuilder : IRootItemBuilder
        {
            this.itemBuilders.Add(itemType, typeof(TBuilder));
        }

        public void RegisterScopeBuilder<TBuilder>(ScopeType scopeType)
            where TBuilder : IRootScopeBuilder
        {
            this.scopeBuilders.Add(scopeType, typeof(TBuilder));
        }
    }
}
