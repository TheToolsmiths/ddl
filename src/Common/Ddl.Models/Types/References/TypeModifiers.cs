namespace TheToolsmiths.Ddl.Models.Types.References
{
    public class TypeModifiers
    {
        public TypeModifiers(bool isConstant)
        {
            this.IsConstant = isConstant;
        }

        private TypeModifiers()
        {
            this.IsConstant = false;
        }

        public static TypeModifiers None { get; } = new TypeModifiers();

        public bool IsConstant { get; }
    }
}
