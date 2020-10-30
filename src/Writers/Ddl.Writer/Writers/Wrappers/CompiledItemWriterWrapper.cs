using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Writers.Wrappers
{
    internal class CompiledItemWriterWrapper<TWriter, TItem> : CompiledItemWriterWrapper
        where TWriter : ICompiledItemWriter<TItem>
        where TItem : class, ICompiledItem
    {
        private readonly TWriter writer;

        public CompiledItemWriterWrapper(TWriter writer)
        {
            this.writer = writer;
        }

        public override Result WriteItem(ICompiledItemWriterContext context, ICompiledItem item)
        {
            return this.writer.WriteItem(context, (TItem)item);
        }
    }

    internal abstract class CompiledItemWriterWrapper
    {
        public abstract Result WriteItem(ICompiledItemWriterContext context, ICompiledItem item);
    }
}
