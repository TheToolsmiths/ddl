using TheToolsmiths.Ddl.Parser.Ast.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public interface IKeyedLiteralAstAttributeUse : IKeyedAstAttributeUse
    {
        LiteralValue Literal { get; }
    }
}
