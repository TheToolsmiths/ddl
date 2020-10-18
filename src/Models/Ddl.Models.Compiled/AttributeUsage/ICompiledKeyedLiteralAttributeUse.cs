using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public interface ICompiledKeyedLiteralAttributeUse : ICompiledKeyedAttributeUse
    {
        LiteralValue Literal { get; }
    }
}
