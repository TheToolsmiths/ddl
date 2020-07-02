using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ConfigurationRegistryBuilder
    {
        private readonly Dictionary<Type, IConfigurationProvider> providers;

        public ConfigurationRegistryBuilder()
        {
            this.providers = new Dictionary<Type, IConfigurationProvider>();
        }

        public ConfigurationProviderCollection Build()
        {
            return new ConfigurationProviderCollection(this.providers);
        }

        public ConfigurationRegistryBuilder AddConfigurationProvider<TProvider>(TProvider instance)
        where TProvider : IConfigurationProvider
        {
            this.providers.Add(typeof(TProvider), instance);

            return this;
        }
    }
}
