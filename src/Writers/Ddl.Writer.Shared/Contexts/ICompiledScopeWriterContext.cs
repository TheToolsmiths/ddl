namespace TheToolsmiths.Ddl.Writer.Contexts
{
    public interface ICompiledScopeWriterContext : ICompiledEntryWriterContext
    {
        new ICommonScopeWriters CommonWriters { get; }
    }
}
