using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ParserConfiguratorProvider
    {
        public ParserConfiguratorProvider(IReadOnlyList<IParserConfigurator> providers)
        {
            this.Providers = providers;
        }

        public IReadOnlyList<IParserConfigurator> Providers { get; }
    }
}
