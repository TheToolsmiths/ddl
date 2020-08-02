using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    public interface IAstConfigurationRegistryBuilder
    {
        bool TryGetCategoryBuilder<TValue>(
            string sectionKey,
            [MaybeNullWhen(false)] out IAstConfigurationSectionBuilder<TValue> sectionBuilder);

        bool TryGetCategoryBuilder(
            string sectionKey,
            [MaybeNullWhen(false)] out IAstConfigurationSectionBuilder sectionBuilder);
    }
}
