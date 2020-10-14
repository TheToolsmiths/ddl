using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public interface IStructInitializationAttributeUse : IAttributeUse
    {
        StructInitialization Initialization { get; }
    }
}
