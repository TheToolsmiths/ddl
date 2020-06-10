namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public interface IAstAttributeUse
    {
        AttributeUseKind UseKind { get; }

        bool IsKeyed { get; }

        bool IsTyped { get; }
    }
}
