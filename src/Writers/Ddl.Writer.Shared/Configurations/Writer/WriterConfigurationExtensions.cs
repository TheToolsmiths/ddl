using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public static class WriterConfigurationExtensions
    {
        public static bool TryGetDefinitionWriterConfigurationBuilder(
            this IDdlConfigurationContext context,
            [NotNullWhen(true)] out IDefinitionWriterConfigurationBuilder? builder)
        {
            return context.TryGetConfigurationBuilder(out builder);
        }
    }
}
