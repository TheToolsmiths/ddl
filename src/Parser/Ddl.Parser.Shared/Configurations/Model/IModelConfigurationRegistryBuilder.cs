using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    public interface IModelConfigurationRegistryBuilder
    {
        bool TryGetCategoryBuilder<TValue>(
            string sectionKey,
            [MaybeNullWhen(false)] out IModelConfigurationSectionBuilder<TValue> sectionBuilder);

        bool TryGetCategoryBuilder(
            string sectionKey,
            [MaybeNullWhen(false)] out IModelConfigurationSectionBuilder sectionBuilder);
    }
}
