using TheToolsmiths.Ddl.Models.Compiled.Types.References;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public interface ITypedAttributeUse : IStructInitializationAttributeUse
    {
        TypeReference Type { get; }
    }
}
