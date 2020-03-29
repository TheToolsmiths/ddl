using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public interface ITypedAttributeUse : IStructInitializationAttributeUse
    {
        ITypeIdentifier Type { get; }
    }
}
