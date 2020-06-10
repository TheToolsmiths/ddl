using TheToolsmiths.Ddl.Parser.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public interface IKeyedLiteralAstAttributeUse : IKeyedAstAttributeUse
    {
        LiteralValue Literal { get; }
    }
}
