namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public interface IAttributeUse
    {
        AttributeUseType UseType { get; }

        bool IsKeyed { get; }

        bool IsTyped { get; }
    }
}