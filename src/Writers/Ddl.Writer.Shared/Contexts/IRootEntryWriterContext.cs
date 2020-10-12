using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Contexts
{
    public interface IRootEntryWriterContext
    {
        IStructuredContentWriter Writer { get; }
    }
}
