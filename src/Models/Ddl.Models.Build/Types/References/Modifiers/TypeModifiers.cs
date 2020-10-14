namespace TheToolsmiths.Ddl.Models.Build.Types.References.Modifiers
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
