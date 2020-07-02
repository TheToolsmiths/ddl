using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ParserConfiguratorCollection
    {
        public ParserConfiguratorCollection(IReadOnlyList<IParserConfigurator> providers)
        {
            this.Providers = providers;
        }

        public IReadOnlyList<IParserConfigurator> Providers { get; }
    }
}
