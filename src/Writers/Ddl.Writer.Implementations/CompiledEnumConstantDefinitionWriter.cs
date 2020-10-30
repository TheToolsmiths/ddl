using TheToolsmiths.Ddl.Models.Compiled.Enums;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Implementations
{
    internal class CompiledEnumConstantDefinitionWriter : ICompiledSubItemWriter<CompiledEnumConstant>
    {
        public Result WriteSubItem(ICompiledItemWriterContext context, CompiledEnumConstant subItem)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteEndObject();

            return Result.Success;
        }
    }
}