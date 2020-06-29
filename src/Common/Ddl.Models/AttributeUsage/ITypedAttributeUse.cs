using TheToolsmiths.Ddl.Models.Types.References;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public interface ITypedAttributeUse : IStructInitializationAttributeUse
    {
        TypeReference Type { get; }
    }
}
