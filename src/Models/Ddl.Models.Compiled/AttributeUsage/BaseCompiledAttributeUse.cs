namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public abstract class BaseCompiledAttributeUse : ICompiledAttributeUse
    {
        public abstract CompiledAttributeUseKind UseKind { get; }

        public abstract bool IsKeyed { get; }

        public abstract bool IsTyped { get; }
    }
}
