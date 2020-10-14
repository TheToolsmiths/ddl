using TheToolsmiths.Ddl.Models.Compiled.Literals;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public interface IKeyedLiteralAttributeUse : IKeyedAttributeUse
    {
        LiteralValue Literal { get; }
    }
}
