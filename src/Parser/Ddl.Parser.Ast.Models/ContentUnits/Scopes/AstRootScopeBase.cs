using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
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
