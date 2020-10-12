using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    public interface IAstConfigurationRegistryBuilder
    {
        bool TryGetCategoryBuilder<TValue>(
            string sectionKey,
            [NotNullWhen(true)] out IAstConfigurationSectionBuilder<TValue>? sectionBuilder);

        bool TryGetCategoryBuilder(
            string sectionKey,
            [NotNullWhen(true)] out IAstConfigurationSectionBuilder? sectionBuilder);
    }
}
