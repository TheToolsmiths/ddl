using System;
using System.Collections.Generic;

using Ddl.Common;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.Values;
using TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.Common.Resolvers
{
    public class CommonResolvers : ICommonResolvers
    {
        private readonly IServiceProvider provider;
        private readonly ScopeItemResolveContext context;

        public CommonResolvers(ScopeItemResolveContext context, IServiceProvider serviceProvider)
        {
            this.context = context;
            this.provider = serviceProvider;
        }

        public Result<ValueInitialization> ResolveValueInitialization(
            Parser.Ast.Models.Values.ValueInitialization astInitialization)
        {
            return this.provider.GetRequiredService<ValueInitializationResolver>().Resolve(this.context, astInitialization);
        }

        public Result<IReadOnlyList<IAttributeUse>> ResolveAttributes(
            IReadOnlyList<Parser.Ast.Models.AttributeUsage.IAttributeUse> astAttributes)
        {
            return this.provider.GetRequiredService<AttributeUseResolver>().ResolveList(this.context, astAttributes);
        }
    }
}
