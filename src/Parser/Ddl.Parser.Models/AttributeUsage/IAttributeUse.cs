namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public interface IAttributeUse
    {
        AttributeUseKind UseKind { get; }

        bool IsKeyed { get; }

        bool IsTyped { get; }
    }
}
