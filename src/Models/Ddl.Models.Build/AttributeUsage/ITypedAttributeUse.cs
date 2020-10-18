using TheToolsmiths.Ddl.Models.Build.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public interface ITypedAttributeUse : IStructInitializationAttributeUse
    {
        TypeUse Type { get; }
    }
}
