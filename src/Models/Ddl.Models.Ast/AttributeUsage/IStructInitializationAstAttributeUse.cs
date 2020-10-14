using TheToolsmiths.Ddl.Models.Ast.Values;

namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public interface IStructInitializationAstAttributeUse : IAstAttributeUse
    {
        StructValueInitialization Initialization { get; }
    }
}
