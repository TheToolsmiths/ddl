using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Models.ContentUnits
{
    public class ContentUnitScope
    {
        public ContentUnitScope(ScopeContent content)
        {
            this.Content = content;
        }

        public ScopeContent Content { get; }
    }
}
