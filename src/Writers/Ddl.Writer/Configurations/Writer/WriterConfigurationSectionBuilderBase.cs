using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    internal abstract class WriterConfigurationSectionBuilderBase
    {
        private readonly Dictionary<ItemType, Type> itemBuilders;
        private readonly Dictionary<SubItemType, Type> subItemBuilders;
        private readonly Dictionary<ScopeType, Type> scopeBuilders;

        protected WriterConfigurationSectionBuilderBase()
        {
            this.itemBuilders = new Dictionary<ItemType, Type>();
            this.subItemBuilders = new Dictionary<SubItemType, Type>();
            this.scopeBuilders = new Dictionary<ScopeType, Type>();
        }

        protected void RegisterTypeValue(ItemType itemType, Type typeValue)
        {
            this.itemBuilders.Add(itemType, typeValue);
        }

        protected void RegisterTypeValue(SubItemType subItemType, Type typeValue)
        {
            this.subItemBuilders.Add(subItemType, typeValue);
        }

        protected void RegisterTypeValue(ScopeType scopeType, Type typeValue)
        {
            this.scopeBuilders.Add(scopeType, typeValue);
        }

        public WriterConfigurationSection Build()
        {
            return new WriterConfigurationSection(this.itemBuilders, this.subItemBuilders, this.scopeBuilders);
        }
    }
}
