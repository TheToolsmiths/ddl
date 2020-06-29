using System;
using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ParserConfiguratorProviderBuilder
    {
        private readonly HashSet<Type> configurators;

        public ParserConfiguratorProviderBuilder()
        {
            this.configurators = new HashSet<Type>();
        }

        public ParserConfiguratorProvider Build()
        {
            var providers = new List<IParserConfigurator>();

            foreach (var providerType in this.configurators.ToList())
            {
                var instance = (IParserConfigurator)Activator.CreateInstance(providerType)!;

                providers.Add(instance);
            }

            return new ParserConfiguratorProvider(providers);
        }

        public ParserConfiguratorProviderBuilder AddConfigurator<T>()
            where T : class, IParserConfigurator, new()
        {
            this.configurators.Add(typeof(T));

            return this;
        }
    }
}
