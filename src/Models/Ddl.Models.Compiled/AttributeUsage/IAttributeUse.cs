namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public interface IAttributeUse
    {
        AttributeUseKind UseKind { get; }

        bool IsKeyed { get; }

        bool IsTyped { get; }
    }
}
