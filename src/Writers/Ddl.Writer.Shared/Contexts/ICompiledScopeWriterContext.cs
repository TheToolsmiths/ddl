namespace TheToolsmiths.Ddl.Writer.Contexts
{
    public interface ICompiledScopeWriterContext : ICompiledEntryWriterContext
    {
        ICommonScopeWriters CommonWriters { get; }
    }
}
