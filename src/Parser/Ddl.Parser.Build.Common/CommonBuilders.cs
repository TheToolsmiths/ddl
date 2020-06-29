using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Common
{
    public class CommonBuilders : ICommonBuilders
    {
        private readonly IServiceProvider provider;
        //private readonly IScopeItemBuildContext context;

        //public CommonBuilders(IScopeItemBuildContext context, IServiceProvider serviceProvider)
        //{
        //    this.context = context;
        //    this.provider = serviceProvider;
        //}

        public Result<ValueInitialization> BuildValueInitialization(
            Ast.Models.Values.ValueInitialization valueInitialization)
        {
            throw new NotImplementedException();
            //return this.provider.GetRequiredService<ValueInitializationBuilder>().Build(this.context, valueInitialization);
        }

        public Result<IReadOnlyList<IAttributeUse>> BuildAttributes(
            IReadOnlyList<Ast.Models.AttributeUsage.IAstAttributeUse> attributes)
        {
            throw new NotImplementedException();

            //return this.provider.GetRequiredService<AttributeUseBuilder>().BuildList(this.context, attributes);
        }
    }
}
