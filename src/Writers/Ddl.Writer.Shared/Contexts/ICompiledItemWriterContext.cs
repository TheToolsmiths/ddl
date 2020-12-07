namespace TheToolsmiths.Ddl.Writer.Contexts
{
    public interface ICompiledItemWriterContext : ICompiledEntryWriterContext
    {
        new ICommonItemWriters CommonWriters { get; }
    }
}
