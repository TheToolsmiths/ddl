using System.Diagnostics.CodeAnalysis;

using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Parser.Build.Configurations
{
    public static class AstConfigurationExtensions
    {
        public static bool TryGetBuilderConfigurationBuilder(
            this IParserConfigurationContext context,
            [MaybeNullWhen(false)] out IBuilderConfigurationBuilder builder)
        {
            return context.TryGetConfigurationBuilder(out builder);
        }
    }
}
