namespace TheToolsmiths.Ddl.Writer.Contexts
{
    public interface IRootItemWriterContext : IRootEntryWriterContext
    {
        ICommonItemWriters CommonWriters { get; }
    }
}
