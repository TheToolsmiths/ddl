namespace TheToolsmiths.Ddl.Parser.Models.Types.Identifiers
{
    public interface IModifierTypeIdentifier : ITypeIdentifier
    {
        ModifierTypeKind ModifierKind { get; }
    }
}
