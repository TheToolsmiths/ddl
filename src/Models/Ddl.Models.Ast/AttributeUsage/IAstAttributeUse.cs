namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public interface IAstAttributeUse
    {
        AttributeUseKind UseKind { get; }

        bool IsKeyed { get; }

        bool IsTyped { get; }
    }
}
