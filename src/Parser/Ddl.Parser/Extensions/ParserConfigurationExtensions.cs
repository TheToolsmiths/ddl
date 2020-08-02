using System.Diagnostics.CodeAnalysis;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.Configurations.Parser;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;

namespace TheToolsmiths.Ddl.Parser.Extensions
{
    public static class ParserConfigurationExtensions
    {
        public static bool TryGetParserMapRegistryBuilder(this IParserConfigurationContext context, [MaybeNullWhen(false)] out IParserMapRegistryBuilder builder)
        {
            if (context.TryGetConfigurationBuilder<IParserConfigurationBuilder>(out var provider))
            {
                builder = provider.RegistryBuilder;
                return true;
            }

            builder = default;
            return false;
        }
    }
}
