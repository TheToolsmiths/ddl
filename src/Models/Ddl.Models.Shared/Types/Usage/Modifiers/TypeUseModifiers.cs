namespace TheToolsmiths.Ddl.Models.Types.Usage.Modifiers
{
    public class TypeUseModifiers
    {
        public TypeUseModifiers(bool isConstant)
        {
            this.IsConstant = isConstant;
        }

        private TypeUseModifiers()
        {
            this.IsConstant = false;
        }

        public static TypeUseModifiers None { get; } = new TypeUseModifiers();

        public bool IsConstant { get; }
    }
}
