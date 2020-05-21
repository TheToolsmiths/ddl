using TheToolsmiths.Ddl.Parser.Ast.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public interface IStructInitializationAttributeUse : IAttributeUse
    {
        StructValueInitialization Initialization { get; }
    }
}
