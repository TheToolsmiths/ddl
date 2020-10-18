using System;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Results;
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

        public Result WriteStructDefinitionContent(StructContent content)
        {
            throw new NotImplementedException();
        }

        // TODO: Uncomment
        //public Result WriteTypeNameResolution(QualifiedItemTypeNameResolution typeNameResolution)
        //{
        //    return this.Provider.GetRequiredService<TypeNameResolutionWriter>().Write(this.context, typeNameResolution);
        //}
    }
}
