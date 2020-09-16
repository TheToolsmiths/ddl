using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Configurations
{
    public interface ITypeResolveConfigurationBuilder : IConfigurationBuilder
    {
        void RegisterItemTypeResolver<T>(ItemType itemType)
            where T : IItemTypeResolver;

        void RegisterScopeTypeResolver<T>(ScopeType scopeType)
            where T : IScopeTypeResolver;

        void RegisterPassthroughTypeResolver(ItemType itemType);
    }
}
