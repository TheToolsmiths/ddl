using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Writers.Wrappers
{
    internal class CompiledSubItemWriterWrapper<TWriter, TSubItem> : CompiledSubItemWriterWrapper
        where TWriter : ICompiledSubItemWriter<TSubItem>
        where TSubItem : class, ICompiledSubItem
    {
        private readonly TWriter writer;

        public CompiledSubItemWriterWrapper(TWriter writer)
        {
            this.writer = writer;
        }

        public override Result WriteSubItem(ICompiledItemWriterContext context, ICompiledSubItem subItem)
        {
            return this.writer.WriteSubItem(context, (TSubItem)subItem);
        }
    }

    internal abstract class CompiledSubItemWriterWrapper
    {
        public abstract Result WriteSubItem(ICompiledItemWriterContext context, ICompiledSubItem subItem);
    }
}
