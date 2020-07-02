using System.Diagnostics.CodeAnalysis;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.Configurations;

namespace TheToolsmiths.Ddl.Parser.Build.Configurations
{
    public static class AstConfigurationExtensions
    {
        public static bool TryGetItemConfigurationBuilder(
            this IParserConfigurationContext context,
            [MaybeNullWhen(false)] out IAstConfigurationSectionBuilder<IRootItemBuilder> builder)
        {
            if (context.TryGetConfigurationProvider<IAstConfigurationProvider>(out var provider) == false)
            {
                builder = default;
                return false;
            }

            return provider.RegistryBuilder.TryGetCategoryBuilder(ConfigurationKeys.BuildConfigurationSection, out builder);
        }

        public static bool TryGetScopeConfigurationBuilder(
            this IParserConfigurationContext context,
            [MaybeNullWhen(false)] out IAstConfigurationSectionBuilder<IRootScopeBuilder> builder)
        {
            if (context.TryGetConfigurationProvider<IAstConfigurationProvider>(out var provider) == false)
            {
                builder = default;
                return false;
            }

            return provider.RegistryBuilder.TryGetCategoryBuilder(ConfigurationKeys.BuildConfigurationSection, out builder);
        }
    }
}
