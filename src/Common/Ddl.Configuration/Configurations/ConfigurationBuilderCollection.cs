using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ConfigurationBuilderCollection
    {
        private readonly IReadOnlyDictionary<Type, ConfigurationBuilder> configurationBuilders;

        public ConfigurationBuilderCollection(IReadOnlyDictionary<Type, ConfigurationBuilder> configurationBuilders)
        {
            this.configurationBuilders = configurationBuilders;
        }

        public IEnumerable<ConfigurationBuilder> ConfigurationBuilders => this.configurationBuilders.Values;

        public bool TryGetConfigurationBuilder<T>([NotNullWhen(true)] out T? builder)
            where T : class, IConfigurationBuilder
        {
            if (this.configurationBuilders.TryGetValue(typeof(T), out var cachedBuilder))
            {
                builder = cachedBuilder as T;

                if (builder == null)
                {
                    throw new NotImplementedException();
                }

                return true;
            }

            builder = default;
            return false;
        }
    }
}
