using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Configurations
{
    public static class ResolveConfigurationExtensions
    {
        public static bool TryGetTypeResolverConfigurationBuilder(
            this IParserConfigurationContext context,
            [NotNullWhen(true)] out ITypeResolveConfigurationBuilder? typeResolveConfigurationBuilder)
        {
            return context.TryGetConfigurationBuilder(out typeResolveConfigurationBuilder);
        }
    }
}
