using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes
{
    public abstract class AstRootScopeBase : IAstRootScope
    {
        protected AstRootScopeBase(AstScopeContent content, AstAttributeUseCollection attributes)
        {
            this.Attributes = attributes;
            this.Content = content;
        }

        public abstract AstScopeType ScopeType { get; }

        public AstAttributeUseCollection Attributes { get; }

        public AstScopeContent Content { get; }
    }
}
