using System;
using Ddl.Common;
using Ddl.Parser.Resolve.Models.FirstPhase.Items.Content;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers
{
    public class EnumStructDefinitionResolver : IRootContentItemResolver<EnumStructDefinitionResolvedContent>
    {
        public Result CatalogItem(
            ScopeItemResolveContext scopeContext,
            EnumStructDefinitionResolvedContent definition)
        {
            var context = new ItemResolveContext();
            
            throw new NotImplementedException();

            return Result.Success;
        }
    }
}
