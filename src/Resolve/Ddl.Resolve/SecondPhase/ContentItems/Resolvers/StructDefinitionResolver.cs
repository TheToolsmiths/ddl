using System;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.Items.Content;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers
{
    public class StructDefinitionResolver : IRootContentItemResolver<StructDefinitionResolvedContent>
    {
        public Result CatalogItem(
            ContentUnitScopeResolveContext unitContext,
            StructDefinitionResolvedContent definition)
        {
            var context = new ItemResolveContext();

            throw new NotImplementedException();

            return Result.Success;
        }
    }
}
