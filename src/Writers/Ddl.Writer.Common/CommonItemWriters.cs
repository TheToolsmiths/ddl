using System;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Models.Compiled.Structs.Content;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Common.Items;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common
{
    public class CommonItemWriters : CommonWriters, ICommonItemWriters
    {
        private readonly ICompiledItemWriterContext context;

        public CommonItemWriters(IServiceProvider provider, ICompiledItemWriterContext context)
            : base(provider, context)
        {
            this.context = context;
        }

        public Result WriteStructDefinitionContent(CompiledStructContent content)
        {
            return this.Provider.GetRequiredService<StructDefinitionContentWriter>().Write(this.context, content);
        }
    }
}
