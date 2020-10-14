namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public abstract class BaseAttributeUse : IAttributeUse
    {
        public abstract AttributeUseKind UseKind { get; }

        public abstract bool IsKeyed { get; }

        public abstract bool IsTyped { get; }
    }
}
