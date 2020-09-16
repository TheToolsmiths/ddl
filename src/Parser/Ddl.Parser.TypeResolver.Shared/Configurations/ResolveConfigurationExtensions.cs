using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Configurations
{
    public static class ResolveConfigurationExtensions
    {
        public static bool TryGetBuilderConfigurationBuilder(
            this IParserConfigurationContext context,
            [MaybeNullWhen(false)] out ITypeResolveConfigurationBuilder typeResolveConfigurationBuilder)
        {
            return context.TryGetConfigurationBuilder(out typeResolveConfigurationBuilder);
        }
    }
}
