using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ParserConfiguratorContext : IParserConfigurationContext
    {
        private readonly ConfigurationBuilderCollection builderCollection;

        public ParserConfiguratorContext(ConfigurationBuilderCollection builderCollection)
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
