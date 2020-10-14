namespace TheToolsmiths.Ddl.Models.Ast.Types.Identifiers
{
    public abstract class ModifierTypeIdentifier : ITypeIdentifier
    {
        protected ModifierTypeIdentifier(IModifiableTypeIdentifier typeIdentifier)
        {
            this.TypeIdentifier = typeIdentifier;
        }

        public IModifiableTypeIdentifier TypeIdentifier { get; }

        public abstract override string ToString();
    }
}
