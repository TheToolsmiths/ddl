using TheToolsmiths.Ddl.Models.Ast.Types.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public interface ITypedAstAttributeUse : IStructInitializationAstAttributeUse
    {
        ITypeIdentifier Type { get; }
    }
}
