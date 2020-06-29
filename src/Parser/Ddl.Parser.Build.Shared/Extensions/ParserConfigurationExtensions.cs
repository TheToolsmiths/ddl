using System.Diagnostics.CodeAnalysis;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.Build.BuilderMaps;
using TheToolsmiths.Ddl.Parser.Build.Configurations;

namespace TheToolsmiths.Ddl.Parser.Build.Extensions
{
    public static class ParserConfigurationExtensions
    {
        public static bool TryGetBuildConfigurationBuilder(
            this IParserConfigurationContext context,
            [MaybeNullWhen(false)] out IBuilderMapRegistryBuilder builder)
        {
            if (context.TryGetConfigurationProvider<BuilderConfigurationProvider>(out var provider))
            {
                builder = provider.RegistryBuilder;
                return true;
            }

            builder = default;
            return false;
        }
    }
}
