using TheToolsmiths.Ddl.Models.Build.Values;

namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public interface IStructInitializationAttributeUse : IAttributeUse
    {
        StructInitialization Initialization { get; }
    }
}
