using TheToolsmiths.Ddl.Parser.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public interface IKeyedLiteralAttributeUse : IKeyedAttributeUse
    {
        LiteralValue Literal { get; }
    }
}
