using System;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    internal class WriterConfigurationSectionBuilder : WriterConfigurationSectionBuilderBase, IWriterConfigurationSectionBuilder
    {
        public new void RegisterTypeValue(ItemType itemType, Type value)
        {
            base.RegisterTypeValue(itemType, value);
        }

        public void RegisterTypeValue(SubItemType subItemType, Type value)
        {
            base.RegisterTypeValue(subItemType, value);
        }

        public new void RegisterTypeValue(ScopeType scopeType, Type value)
        {
            base.RegisterTypeValue(scopeType, value);
        }
    }

    internal class WriterConfigurationSectionBuilder<T> : WriterConfigurationSectionBuilderBase, IWriterConfigurationSectionBuilder<T>
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
