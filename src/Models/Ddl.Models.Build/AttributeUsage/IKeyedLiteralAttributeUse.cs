using TheToolsmiths.Ddl.Models.Build.Literals;

namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public interface IKeyedLiteralAttributeUse : IKeyedAttributeUse
    {
        LiteralValue Literal { get; }
    }
}
