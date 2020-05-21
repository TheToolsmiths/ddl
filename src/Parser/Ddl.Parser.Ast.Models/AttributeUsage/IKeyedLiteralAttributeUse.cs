using TheToolsmiths.Ddl.Parser.Ast.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public interface IKeyedLiteralAttributeUse : IKeyedAttributeUse
    {
        LiteralValue Literal { get; }
    }
}