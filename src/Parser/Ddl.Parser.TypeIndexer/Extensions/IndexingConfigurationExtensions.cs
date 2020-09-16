using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Configurations;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Extensions
{
    public static class IndexingConfigurationExtensions
    {
        public static bool TryGetIndexingConfigurationBuilder(
            this IParserConfigurationContext context,
            [MaybeNullWhen(false)] out IIndexingConfigurationBuilder builder)
        {
            return context.TryGetConfigurationBuilder(out builder);
        }
    }
}
