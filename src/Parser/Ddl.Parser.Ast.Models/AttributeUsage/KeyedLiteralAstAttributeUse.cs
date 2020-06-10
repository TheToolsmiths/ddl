using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public class KeyedLiteralAstAttributeUse : BaseAstAttributeUse, IKeyedLiteralAstAttributeUse
    {
        public KeyedLiteralAstAttributeUse(Identifier key, LiteralValue literal)
        {
            this.Key = key;
            this.Literal = literal;
        }

        public override AttributeUseKind UseKind => AttributeUseKind.KeyedLiteral;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public Identifier Key { get; }

        public LiteralValue Literal { get; }
    }
}
