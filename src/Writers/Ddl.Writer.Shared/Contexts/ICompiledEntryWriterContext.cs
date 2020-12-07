using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Contexts
{
    public interface ICompiledEntryWriterContext
    {
        IStructuredContentWriter Writer { get; }

        ICommonWriters CommonWriters { get; }
        
        IEntityKeyMap EntityKeyMap { get; }
    }
}
