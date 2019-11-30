namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public abstract class BaseTypedAttributeUse : BaseAttributeUse, ITypedAttributeUse
    {
        protected BaseTypedAttributeUse(TypeIdentifier type, StructValueInitialization initialization)
        {
            Type = type;
            Initialization = initialization;
        }

        public TypeIdentifier Type { get; }

        public StructValueInitialization Initialization { get; }
    }
}