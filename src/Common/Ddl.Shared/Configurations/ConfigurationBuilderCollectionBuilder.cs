using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ConfigurationBuilderCollectionBuilder
    {
        private readonly Dictionary<Type, IConfigurationBuilder> builders;

        public ConfigurationBuilderCollectionBuilder()
        {
            this.builders = new Dictionary<Type, IConfigurationBuilder>();
        }

        public ConfigurationBuilderCollection Build()
        {
            return new ConfigurationBuilderCollection(this.builders);
        }

        public ConfigurationBuilderCollectionBuilder AddConfigurationBuilder<TBuilder>(TBuilder instance)
            where TBuilder : IConfigurationBuilder
        {
            this.builders.Add(typeof(TBuilder), instance);

            return this;
        }
    }
}
