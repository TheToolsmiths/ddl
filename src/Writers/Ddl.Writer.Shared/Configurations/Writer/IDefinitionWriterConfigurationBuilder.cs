using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public interface IDefinitionWriterConfigurationBuilder : IConfigurationBuilder
    {
        void RegisterItemWriter<T>(ItemType itemType)
            where T : ICompiledItemWriter;

        void RegisterSubItemWriter<T>(SubItemType subItemType)
            where T : ICompiledSubItemWriter;
    }
}
