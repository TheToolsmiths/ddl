using TheToolsmiths.Ddl.Parser.Models.Types.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public interface ITypedAttributeUse : IStructInitializationAttributeUse
    {
        ITypeIdentifier Type { get; }
    }
}
