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
            where T : class, IConfigurationProvider
        {
            if (this.configurationProviders.TryGetValue(typeof(T), out var cachedProvider))
            {
                provider = cachedProvider as T;

                if (provider == null)
                {
                    throw new NotImplementedException();
                }

                return true;
            }

            provider = default;
            return false;
        }
    }
}
