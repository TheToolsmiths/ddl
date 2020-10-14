using TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits
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
