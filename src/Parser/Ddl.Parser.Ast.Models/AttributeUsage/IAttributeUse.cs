namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public interface IAttributeUse
    {
        AttributeUseKind UseKind { get; }

        bool IsKeyed { get; }

        bool IsTyped { get; }
    }
}
