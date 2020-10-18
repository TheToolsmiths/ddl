using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Compiled.Scopes
{
    public class CompiledScope : CompiledScopeBase, IAttributableCompiledScope
    {
        public CompiledScope(CompiledScopeContent content, CompiledAttributeUseCollection attributes)
            : base(content)
        {
            this.Attributes = attributes;
        }

        public override ScopeType ScopeType => CommonScopeTypes.RootScope;

        public CompiledAttributeUseCollection Attributes { get; }
    }
}
