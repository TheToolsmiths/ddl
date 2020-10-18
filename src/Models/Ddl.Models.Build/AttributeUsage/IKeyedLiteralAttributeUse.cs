using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public interface IKeyedLiteralAttributeUse : IKeyedAttributeUse
    {
        LiteralValue Literal { get; }
    }
}
