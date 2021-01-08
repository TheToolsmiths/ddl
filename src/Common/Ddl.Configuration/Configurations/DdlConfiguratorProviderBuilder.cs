using System;
using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Configurations
{
    public class DdlConfiguratorProviderBuilder
    {
        private readonly HashSet<Type> configurators;

        public DdlConfiguratorProviderBuilder()
        {
            this.configurators = new HashSet<Type>();
        }

        public DdlConfiguratorCollection Build()
        {
            var providers = new List<IDdlConfigurator>();

            foreach (var providerType in this.configurators.ToList())
            {
                var instance = (IDdlConfigurator)Activator.CreateInstance(providerType)!;

                providers.Add(instance);
            }

            return new DdlConfiguratorCollection(providers);
        }

        public DdlConfiguratorProviderBuilder AddConfigurator<T>()
            where T : class, IDdlConfigurator, new()
        {
            this.configurators.Add(typeof(T));

            return this;
        }
    }
}
