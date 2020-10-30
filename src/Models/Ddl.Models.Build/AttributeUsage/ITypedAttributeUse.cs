using TheToolsmiths.Ddl.Models.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public interface ITypedAttributeUse : IStructInitializationAttributeUse
    {
        TypeUse Type { get; }
    }
}
