using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public interface IKeyedLiteralAttributeUse : IKeyedAttributeUse
    {
        LiteralValue Literal { get; }
    }
}
