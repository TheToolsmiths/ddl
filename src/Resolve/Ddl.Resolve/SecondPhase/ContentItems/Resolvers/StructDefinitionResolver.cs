using System;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.Items.Content;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers
{
    public class StructDefinitionResolver : IRootContentItemResolver<StructDefinitionResolvedContent>
    {
        public Result CatalogItem(
            ScopeItemResolveContext unitContext,
            StructDefinitionResolvedContent definition)
        {
            var context = new ItemResolveContext();

            var content = definition.Content;
            

            throw new NotImplementedException();

            return Result.Success;
        }
    }
}
