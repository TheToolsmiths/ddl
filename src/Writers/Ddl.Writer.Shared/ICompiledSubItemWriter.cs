using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer
{
    public interface ICompiledSubItemWriter<TSubItem> : ICompiledSubItemWriter
        where TSubItem : class, ICompiledSubItem
    {
        public Result WriteSubItem(ICompiledItemWriterContext context, TSubItem subItem);
    }

    public interface ICompiledSubItemWriter
    {
    }
}
