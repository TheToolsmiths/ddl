using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Configurations
{
    public static class IndexingConfigurationExtensions
    {
        public static bool TryGetIndexingConfigurationBuilder(
            this IDdlConfigurationContext context,
            [NotNullWhen(true)] out IIndexingConfigurationBuilder? indexingConfigurationBuilder)
        {
            return context.TryGetConfigurationBuilder(out indexingConfigurationBuilder);
        }
    }
}
