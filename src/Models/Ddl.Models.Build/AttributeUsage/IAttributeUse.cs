namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public interface IAttributeUse
    {
        AttributeUseKind UseKind { get; }

        bool IsKeyed { get; }

        bool IsTyped { get; }
    }
}
