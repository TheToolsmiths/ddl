using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Configurations
{
    public class DdlConfiguratorContext : IDdlConfigurationContext
    {
        private readonly ConfigurationBuilderCollection builderCollection;

        public DdlConfiguratorContext(ConfigurationBuilderCollection builderCollection)
        {
            this.builderCollection = builderCollection;
        }

        public bool TryGetConfigurationBuilder<T>([NotNullWhen(true)] out T? builder)
            where T : class, IConfigurationBuilder
        {
            return this.builderCollection.TryGetConfigurationBuilder(out builder);
        }
    }
}
