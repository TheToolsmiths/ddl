using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ConfigurationRegistryBuilder
    {
        private readonly Dictionary<Type, Type> providers;

        public ConfigurationRegistryBuilder()
        {
            this.providers = new Dictionary<Type, Type>();
        }

        public ConfigurationProviderCollection Build()
        {
            var map = new Dictionary<Type, IConfigurationProvider>();

            foreach (var (providerType, instanceType) in this.providers)
            {
                var instance = (IConfigurationProvider)Activator.CreateInstance(instanceType)!;

                map.Add(providerType, instance);
            }

            return new ConfigurationProviderCollection(map);
        }

        public ConfigurationRegistryBuilder AddProvider<TProvider, TInstance>()
        where TProvider : IConfigurationProvider
        where TInstance : class, IConfigurationProvider, TProvider, new()
        {
            this.providers.Add(typeof(TProvider), typeof(TInstance));

            return this;
        }
    }
}
