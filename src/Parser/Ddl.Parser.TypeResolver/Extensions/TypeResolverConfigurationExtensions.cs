using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.TypeResolver.Configurations;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Extensions
{
    public static class TypeResolverConfigurationExtensions
    {
        public static bool TryGetTypeResolverConfigurationBuilder(
            this IParserConfigurationContext context,
            [MaybeNullWhen(false)] out ITypeResolveConfigurationBuilder builder)
        {
            return context.TryGetConfigurationBuilder(out builder);
        }
    }
}
