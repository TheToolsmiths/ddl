using System;
using TheToolsmiths.Ddl.Models.Compiled.Enums;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Implementations
{
    internal class CompiledEnumStructVariantDefinitionWriter : ICompiledSubItemWriter<CompiledEnumStructVariant>
    {
        public Result WriteSubItem(ICompiledItemWriterContext context, CompiledEnumStructVariant subItem)
        {
            context.Writer.WriteStartObject();

            context.Writer.WritePropertyName("content");

            var result = context.CommonWriters.WriteStructDefinitionContent(subItem.Content);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            context.Writer.WriteEndObject();

            return Result.Success;
        }
    }
}
