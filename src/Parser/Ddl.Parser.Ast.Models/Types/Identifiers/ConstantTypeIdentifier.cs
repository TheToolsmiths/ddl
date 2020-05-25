namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers
{
    public class ConstantTypeIdentifier : ModifierTypeIdentifier
    {
        public ConstantTypeIdentifier(IModifiableTypeIdentifier typeIdentifier)
            : base(typeIdentifier)
        {
        }

        public override string ToString()
        {
            return $"const {this.TypeIdentifier}";
        }
    }
}
