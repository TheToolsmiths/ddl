using TheToolsmiths.Ddl.Models.Build.ContentUnits;

namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class ContentUnitScopeBuildSuccess : ContentUnitScopeBuildResult
    {
        public ContentUnitScopeBuildSuccess(ContentUnitScope scope)
            : base(ContentUnitScopeBuildResultKind.Success)
        {
            this.Scope = scope;
        }

        public ContentUnitScope Scope { get; }
    }
}