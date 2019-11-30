namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public class TypedAttributeUse : BaseTypedAttributeUse, ITypedAttributeUse
    {
        public TypedAttributeUse(TypeIdentifier type, StructValueInitialization initialization)
            : base(type, initialization)
        {
        }

        public override AttributeUseType UseType => AttributeUseType.Typed;

        public override bool IsKeyed => false;

        public override bool IsTyped => true;
    }
}