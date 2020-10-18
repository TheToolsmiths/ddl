namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public interface ICompiledAttributeUse
    {
        CompiledAttributeUseKind UseKind { get; }

        bool IsKeyed { get; }

        bool IsTyped { get; }
    }
}
