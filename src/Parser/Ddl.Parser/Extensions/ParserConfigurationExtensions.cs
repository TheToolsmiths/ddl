using System.Diagnostics.CodeAnalysis;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.Configurations;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;

namespace TheToolsmiths.Ddl.Parser.Extensions
{
    public static class ParserConfigurationExtensions
    {
        public static bool TryGetParserMapRegistryBuilder(this IParserConfigurationContext context, [MaybeNullWhen(false)] out IParserMapRegistryBuilder builder)
        {
            if (context.TryGetConfigurationProvider<ParserConfigurationProvider>(out var provider))
            {
                builder = provider.RegistryBuilder;
                return true;
            }

            builder = default;
            return false;
        }
    }
}
