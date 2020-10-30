namespace TheToolsmiths.Ddl.Writer.Contexts
{
    public interface ICompiledItemWriterContext : ICompiledEntryWriterContext
    {
        ICommonItemWriters CommonWriters { get; }
    }
}
