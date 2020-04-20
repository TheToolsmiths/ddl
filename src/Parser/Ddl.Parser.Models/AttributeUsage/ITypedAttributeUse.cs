using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public interface ITypedAttributeUse : IStructInitializationAttributeUse
    {
        ITypeIdentifier Type { get; }
    }
}
