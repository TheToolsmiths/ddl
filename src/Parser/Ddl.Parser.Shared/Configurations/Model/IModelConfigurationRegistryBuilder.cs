using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    public interface IModelConfigurationRegistryBuilder
    {
        bool TryGetCategoryBuilder<TValue>(
            string sectionKey,
            [NotNullWhen(true)] out IModelConfigurationSectionBuilder<TValue>? sectionBuilder);

        bool TryGetCategoryBuilder(
            string sectionKey,
            [NotNullWhen(true)] out IModelConfigurationSectionBuilder? sectionBuilder);
    }
}
