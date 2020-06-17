using TheToolsmiths.Ddl.Parser.Build.Contexts;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    public class ContentUnitScopeBuildContext : IRootItemBuildContext
    {
        private ContentUnitScopeBuildContext(ICommonBuilders commonBuilders)
        {
            this.CommonBuilders = commonBuilders;
        }

        public ICommonBuilders CommonBuilders { get; }

        public static ContentUnitScopeBuildContext CreateRootContext(ICommonBuilders commonBuilders)
        {
            return new ContentUnitScopeBuildContext(commonBuilders);
        }

        public ContentUnitScopeBuildContext CreateChildContext()
        {
            return new ContentUnitScopeBuildContext(this.CommonBuilders);
        }

        // TODO: Delete
        //public ContentUnitScopeBuildContext CreateScopeWithAdditionalProperties(
        //    IEnumerable<ScopeProperty> additionalProperties)
        //{
        //    var properties = this.Properties.ToList();

        //    properties.AddRange(additionalProperties);

        //    return new ContentUnitScopeBuildContext(this.CommonBuilders, properties);
        //}
    }
}
