using TheToolsmiths.Ddl.Parser.Ast.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public interface IStructInitializationAstAttributeUse : IAstAttributeUse
    {
        StructValueInitialization Initialization { get; }
    }
}
