using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public interface IStructInitializationAttributeUse : IAttributeUse
    {
        StructInitialization Initialization { get; }
    }
}
