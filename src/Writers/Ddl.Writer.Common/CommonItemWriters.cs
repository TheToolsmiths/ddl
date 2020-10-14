using System;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Common.Types;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common
{
    public class CommonItemWriters : CommonWriters, ICommonItemWriters
    {
        private readonly IRootItemWriterContext context;

        public CommonItemWriters(IServiceProvider provider, IRootItemWriterContext context)
            : base(provider, context)
        {
            this.context = context;
        }

        public Result WriteStructDefinitionContent(StructDefinitionContent content)
        {
            throw new NotImplementedException();
        }

        public Result WriteTypeNameResolution(QualifiedItemTypeNameResolution typeNameResolution)
        {
            return this.Provider.GetRequiredService<TypeNameResolutionWriter>().Write(this.context, typeNameResolution);
        }
    }
}
