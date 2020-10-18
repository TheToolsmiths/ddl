using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Configurations
{
    public interface IIndexingConfigurationBuilder : IConfigurationBuilder
    {
        void RegisterItemIndexer<T>(ItemType itemType)
            where T : IRootItemIndexer;
    }
}
