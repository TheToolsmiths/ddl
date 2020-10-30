using System;

using TheToolsmiths.Ddl.Models.Compiled.Structs;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Implementations
{
    internal class CompiledStructDefinitionWriter : ICompiledItemWriter<CompiledStructDefinition>
    {
        public Result WriteItem(ICompiledItemWriterContext context, CompiledStructDefinition item)
        {
            context.Writer.WriteStartObject();

            context.Writer.WritePropertyName("content");

            var result = context.CommonWriters.WriteStructDefinitionContent(item.Content);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            context.Writer.WriteEndObject();

            return Result.Success;
        }
    }
}
