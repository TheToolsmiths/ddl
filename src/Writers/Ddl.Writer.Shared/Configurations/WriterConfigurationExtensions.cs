using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Writer.Configurations
{
    public static class WriterConfigurationExtensions
    {
        public static bool TryGetWriterConfigurationBuilder(
            this IParserConfigurationContext context,
            [MaybeNullWhen(false)] out IWriterConfigurationBuilder builder)
        {
            return context.TryGetConfigurationBuilder(out builder);
        }
    }
}
