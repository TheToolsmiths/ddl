using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;
using TheToolsmiths.Ddl.Writer.Writers;

namespace TheToolsmiths.Ddl.Writer
{
    internal class CompiledSubItemDefinitionWriter
    {
        private readonly CompiledSubItemDefinitionWriterResolver writerResolver;

        public CompiledSubItemDefinitionWriter(CompiledSubItemDefinitionWriterResolver writerResolver)
        {
            this.writerResolver = writerResolver;
        }

        public Result Write(ICompiledItemWriterContext context, ICompiledSubItem subItem)
        {
            if (this.writerResolver.TryResolveSubItemDefinitionWriter(subItem, out var itemWriter) == false)
            {
                throw new System.NotImplementedException();
            }

            return itemWriter.WriteSubItem(context, subItem);
        }
    }
}
