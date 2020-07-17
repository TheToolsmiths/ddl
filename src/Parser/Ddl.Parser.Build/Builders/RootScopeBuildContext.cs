using System;

using TheToolsmiths.Ddl.Parser.Build.Common;
using TheToolsmiths.Ddl.Parser.Build.Contexts;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    public class RootScopeBuildContext : IRootScopeBuildContext
    {
        private RootScopeBuildContext(IServiceProvider serviceProvider)
        {
            this.CommonBuilders = new CommonBuilders(serviceProvider, this);
        }

        private RootScopeBuildContext(CommonBuilders commonBuilders)
        {
            this.CommonBuilders = commonBuilders.CreateForScope(this);
        }

        public CommonBuilders CommonBuilders { get; }

        ICommonBuilders IRootEntryBuildContext.CommonBuilders => this.CommonBuilders;

        public static RootScopeBuildContext CreateRootContext(IServiceProvider serviceProvider)
        {
            return new RootScopeBuildContext(serviceProvider);
        }

        public IRootScopeBuildContext CreateScopeContext()
        {
            return new RootScopeBuildContext(this.CommonBuilders);
        }

        public IRootItemBuildContext CreateItemContext()
        {
            return new RootItemBuildContext(this.CommonBuilders);
        }
    }
}
