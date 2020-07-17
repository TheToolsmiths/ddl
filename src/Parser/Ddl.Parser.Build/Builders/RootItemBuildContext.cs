using TheToolsmiths.Ddl.Parser.Build.Contexts;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    public class RootItemBuildContext : IRootItemBuildContext
    {
        public RootItemBuildContext(ICommonBuilders commonBuilders)
        {
            this.CommonBuilders = commonBuilders;
        }

        public ICommonBuilders CommonBuilders { get; }
    }
}
