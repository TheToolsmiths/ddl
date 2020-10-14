using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    internal abstract class ModelConfigurationSectionBuilderBase
    {
        private readonly Dictionary<ItemType, Type> itemBuilders;
        private readonly Dictionary<ScopeType, Type> scopeBuilders;

        protected ModelConfigurationSectionBuilderBase()
        {
            this.itemBuilders = new Dictionary<ItemType, Type>();
            this.scopeBuilders = new Dictionary<ScopeType, Type>();
        }

        protected void RegisterTypeValue(ItemType itemType, Type typeValue)
        {
            this.itemBuilders.Add(itemType, typeValue);
        }

        protected void RegisterTypeValue(ScopeType scopeType, Type typeValue)
        {
            this.scopeBuilders.Add(scopeType, typeValue);
        }

        public ModelConfigurationSection Build()
        {
            return new ModelConfigurationSection(this.itemBuilders, this.scopeBuilders);
        }
    }
}
