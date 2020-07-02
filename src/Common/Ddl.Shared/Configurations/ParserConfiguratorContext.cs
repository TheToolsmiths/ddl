using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ParserConfiguratorContext : IParserConfigurationContext
    {
        private readonly ConfigurationProviderCollection providerCollection;

        public ParserConfiguratorContext(ConfigurationProviderCollection providerCollection)
        {
            this.providerCollection = providerCollection;
        }

        public bool TryGetConfigurationProvider<T>([MaybeNullWhen(false)] out T provider)
            where T : class, IConfigurationProvider
        {
            return this.providerCollection.TryGetConfigurationProvider(out provider);
        }
    }
}
