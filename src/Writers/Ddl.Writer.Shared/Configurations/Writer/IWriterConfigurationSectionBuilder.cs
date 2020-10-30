using System;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public interface IWriterConfigurationSectionBuilder<in T>
    {
        void RegisterTypeValue<TValue>(ItemType itemType)
            where TValue : T;

        void RegisterTypeValue<TValue>(ScopeType scopeType)
            where TValue : T;
    }

    public interface IWriterConfigurationSectionBuilder
    {
        void RegisterTypeValue(ItemType itemType, Type value);
        
        void RegisterTypeValue(SubItemType subItemType, Type value);

        void RegisterTypeValue(ScopeType scopeType, Type value);
    }
}
