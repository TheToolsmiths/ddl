using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public interface ITypedAstAttributeUse : IStructInitializationAstAttributeUse
    {
        ITypeIdentifier Type { get; }
    }
}
