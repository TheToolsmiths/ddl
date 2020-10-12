namespace TheToolsmiths.Ddl.Writer.Contexts
{
    public interface IRootScopeWriterContext : IRootEntryWriterContext
    {
        ICommonScopeWriters CommonWriters { get; }

        IRootScopeWriterContext CreateScopeContext();

        IRootItemWriterContext CreateItemContext();
    }
}
