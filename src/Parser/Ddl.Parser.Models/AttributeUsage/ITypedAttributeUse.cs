using TheToolsmiths.Ddl.Parser.Models.Types.References;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public interface ITypedAttributeUse : IStructInitializationAttributeUse
    {
        TypeReference Type { get; }
    }
}
