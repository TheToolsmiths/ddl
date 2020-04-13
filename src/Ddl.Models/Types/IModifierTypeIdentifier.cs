namespace TheToolsmiths.Ddl.Models.Types
{
    public interface IModifierTypeIdentifier : ITypeIdentifier
    {
        ModifierTypeKind ModifierKind { get; }
    }
}
