namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers
{
    public interface IModifierTypeIdentifier : ITypeIdentifier
    {
        ModifierTypeKind ModifierKind { get; }
    }
}
