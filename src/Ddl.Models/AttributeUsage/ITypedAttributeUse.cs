namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public interface ITypedAttributeUse : IAttributeUse
    {
        TypeIdentifier Type { get; }

        StructValueInitialization Initialization { get; }
    }
}