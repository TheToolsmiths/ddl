using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public interface IKeyedAstAttributeUse : IAstAttributeUse
    {
        Identifier Key { get; }
    }
}