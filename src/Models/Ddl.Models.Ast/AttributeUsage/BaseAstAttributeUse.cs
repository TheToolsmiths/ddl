namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public abstract class BaseAstAttributeUse : IAstAttributeUse
    {
        public abstract AttributeUseKind UseKind { get; }

        public abstract bool IsKeyed { get; }

        public abstract bool IsTyped { get; }
    }
}
