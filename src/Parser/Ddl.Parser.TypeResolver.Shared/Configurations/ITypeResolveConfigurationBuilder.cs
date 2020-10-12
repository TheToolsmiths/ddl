using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Configurations
{
    public interface ITypeResolveConfigurationBuilder : IConfigurationBuilder
    {
        void RegisterTypeResolver<T>(ItemType itemType)
            where T : IItemTypeResolver;

        void RegisterTypeResolver<T>(ScopeType scopeType)
            where T : IScopeTypeResolver;

        void RegisterPassthroughTypeResolver(ItemType itemType);
    }
}
