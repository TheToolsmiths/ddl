using TheToolsmiths.Ddl.Models.Ast.Literals;

namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public interface IKeyedLiteralAstAttributeUse : IKeyedAstAttributeUse
    {
        LiteralValue Literal { get; }
    }
}
