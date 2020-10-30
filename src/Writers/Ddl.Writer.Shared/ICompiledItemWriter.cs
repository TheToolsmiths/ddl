using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer
{
    public interface ICompiledItemWriter<TItem> : ICompiledItemWriter
        where TItem : class, ICompiledItem
    {
        public Result WriteItem(ICompiledItemWriterContext context, TItem item);
    }

    public interface ICompiledItemWriter
    {
    }
}
