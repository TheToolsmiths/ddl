namespace TheToolsmiths.Ddl.Parser.Models.Types
{
    public interface IModifierTypeIdentifier : ITypeIdentifier
    {
        ModifierTypeKind ModifierKind { get; }
    }
}
