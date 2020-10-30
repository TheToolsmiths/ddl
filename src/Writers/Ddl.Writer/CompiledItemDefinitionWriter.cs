using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;
using TheToolsmiths.Ddl.Writer.Writers;

namespace TheToolsmiths.Ddl.Writer
{
    internal class CompiledItemDefinitionWriter
    {
        private readonly CompiledItemDefinitionWriterResolver writerResolver;

        public CompiledItemDefinitionWriter(CompiledItemDefinitionWriterResolver writerResolver)
        {
            this.writerResolver = writerResolver;
        }

        public Result Write(ICompiledItemWriterContext context, ICompiledItem item)
        {
            if (this.writerResolver.TryResolveItemDefinitionWriter(item, out var itemWriter) == false)
            {
                throw new System.NotImplementedException();
            }

            return itemWriter.WriteItem(context, item);
        }
    }
}
