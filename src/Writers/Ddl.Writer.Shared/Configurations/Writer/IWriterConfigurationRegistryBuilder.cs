using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public interface IWriterConfigurationRegistryBuilder
    {
        bool TryGetCategoryBuilder<TValue>(
            string sectionKey,
            [NotNullWhen(true)] out IWriterConfigurationSectionBuilder<TValue>? sectionBuilder);

        bool TryGetCategoryBuilder(
            string sectionKey,
            [NotNullWhen(true)] out IWriterConfigurationSectionBuilder? sectionBuilder);
    }
}
