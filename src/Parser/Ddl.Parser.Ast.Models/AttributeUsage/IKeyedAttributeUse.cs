using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public interface IKeyedAttributeUse : IAttributeUse
    {
        Identifier Key { get; }
    }
}