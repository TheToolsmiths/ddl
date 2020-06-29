using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Build.BuilderMaps
{
    public interface IBuilderMapRegistryBuilder
    {
        void RegisterItemBuilder<TBuilder>(ItemType itemType)
            where TBuilder : IRootItemBuilder;

        void RegisterScopeBuilder<TBuilder>(ScopeType scopeType)
            where TBuilder : IRootScopeBuilder;
    }
}
