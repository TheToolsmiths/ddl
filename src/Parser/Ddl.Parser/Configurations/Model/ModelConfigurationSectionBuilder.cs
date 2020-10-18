using System;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    internal class ModelConfigurationSectionBuilder : ModelConfigurationSectionBuilderBase, IModelConfigurationSectionBuilder
    {
        public new void RegisterTypeValue(ItemType itemType, Type value)
        {
            base.RegisterTypeValue(itemType, value);
        }

        public new void RegisterTypeValue(ScopeType scopeType, Type value)
        {
            base.RegisterTypeValue(scopeType, value);
        }
    }

    internal class ModelConfigurationSectionBuilder<T> : ModelConfigurationSectionBuilderBase, IModelConfigurationSectionBuilder<T>
    {
        public void RegisterTypeValue<TValue>(ItemType itemType)
            where TValue : T
        {
            base.RegisterTypeValue(itemType, typeof(TValue));
        }

        public void RegisterTypeValue<TValue>(ScopeType scopeType)
            where TValue : T
        {
            base.RegisterTypeValue(scopeType, typeof(TValue));
        }
    }
}
