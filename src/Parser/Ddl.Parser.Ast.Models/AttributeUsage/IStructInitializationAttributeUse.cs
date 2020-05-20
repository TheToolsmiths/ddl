using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public interface IStructInitializationAttributeUse : IAttributeUse
    {
        StructValueInitialization Initialization { get; }
    }
}
