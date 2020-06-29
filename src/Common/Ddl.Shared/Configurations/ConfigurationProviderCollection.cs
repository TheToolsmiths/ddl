using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ConfigurationProviderCollection
    {
        private readonly IReadOnlyDictionary<Type, IConfigurationProvider> configurationProviders;

        public ConfigurationProviderCollection(IReadOnlyDictionary<Type, IConfigurationProvider> configurationProviders)
        {
            this.configurationProviders = configurationProviders;
        }

        public IEnumerable<IConfigurationProvider> ConfigurationProviders => this.configurationProviders.Values;

        public bool TryGetConfigurationProvider<T>([MaybeNullWhen(false)] out T provider)
            where T : IConfigurationProvider
        {
            if (this.configurationProviders.TryGetValue(typeof(T), out var cachedProvider))
            {
                if (cachedProvider.GetType() != typeof(T))
                {
                    throw new NotImplementedException();
                }

                provider = (T)cachedProvider;
                return true;
            }

            provider = default;
            return false;
        }
    }
}
