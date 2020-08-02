using System;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    public interface IModelConfigurationSectionBuilder
    {
        void RegisterTypeValue(ItemType itemType, Type value);

        void RegisterTypeValue(ScopeType scopeType, Type value);
    }

    public interface IModelConfigurationSectionBuilder<in T>
    {
        void RegisterTypeValue<TValue>(ItemType itemType)
            where TValue : T;

        void RegisterTypeValue<TValue>(ScopeType scopeType)
            where TValue : T;
    }
}
