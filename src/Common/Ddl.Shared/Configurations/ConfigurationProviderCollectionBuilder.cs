using System;
using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ConfigurationProviderCollectionBuilder
    {
        private readonly HashSet<Type> providers;

        public ConfigurationProviderCollectionBuilder()
        {
            this.providers = new HashSet<Type>();
        }

        public ConfigurationProviderCollection Build()
        {
            var map = new Dictionary<Type, IConfigurationProvider>();

            foreach (var providerType in this.providers.ToList())
            {
                var instance = (IConfigurationProvider)Activator.CreateInstance(providerType)!;

                map.Add(providerType, instance);
            }

            return new ConfigurationProviderCollection(map);
        }

        public ConfigurationProviderCollectionBuilder AddProvider<T>()
        where T : class, IConfigurationProvider, new()
        {
            this.providers.Add(typeof(T));

            return this;
        }
    }
}
