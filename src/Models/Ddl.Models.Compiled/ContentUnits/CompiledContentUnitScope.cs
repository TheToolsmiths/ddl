using TheToolsmiths.Ddl.Models.Compiled.Scopes;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits
{
    public class CompiledContentUnitScope
    {
        public CompiledContentUnitScope(CompiledScopeContent content)
        {
            this.Content = content;
        }

        public CompiledScopeContent Content { get; }
    }
}
