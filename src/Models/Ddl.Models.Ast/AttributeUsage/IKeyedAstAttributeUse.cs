using TheToolsmiths.Ddl.Models.Ast.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public interface IKeyedAstAttributeUse : IAstAttributeUse
    {
        Identifier Key { get; }
    }
}