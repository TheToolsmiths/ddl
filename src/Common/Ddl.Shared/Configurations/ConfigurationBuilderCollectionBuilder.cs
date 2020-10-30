using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ConfigurationBuilderCollectionBuilder
    {
        private readonly Dictionary<Type, ConfigurationBuilder> builders;

        public ConfigurationBuilderCollectionBuilder()
        {
            this.builders = new Dictionary<Type, ConfigurationBuilder>();
        }

        public ConfigurationBuilderCollection Build()
        {
            return new ConfigurationBuilderCollection(this.builders);
        }

        public ConfigurationBuilderCollectionBuilder AddConfigurationBuilder<TBuilder, TInstance>(TInstance instance)
            where TBuilder : IConfigurationBuilder
            where TInstance : ConfigurationBuilder, TBuilder
        {
            this.builders.Add(typeof(TBuilder), instance);

            return this;
        }
    }
}
