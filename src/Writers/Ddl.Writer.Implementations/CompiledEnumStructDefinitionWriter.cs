using TheToolsmiths.Ddl.Models.Compiled.Enums;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Implementations
{
    internal class CompiledEnumStructDefinitionWriter : ICompiledItemWriter<CompiledEnumStructDefinition>
    {
        public Result WriteItem(ICompiledItemWriterContext context, CompiledEnumStructDefinition item)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteEndObject();

            return Result.Success;
        }
    }
}
