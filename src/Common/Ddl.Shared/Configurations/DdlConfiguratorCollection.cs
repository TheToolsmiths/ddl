using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Configurations
{
    public class DdlConfiguratorCollection
    {
        public DdlConfiguratorCollection(IReadOnlyList<IDdlConfigurator> providers)
        {
            this.Providers = providers;
        }

        public IReadOnlyList<IDdlConfigurator> Providers { get; }
    }
}
