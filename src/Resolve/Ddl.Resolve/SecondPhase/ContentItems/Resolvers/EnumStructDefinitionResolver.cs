using System;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.Items.Content;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers
{
    public class EnumStructDefinitionResolver : IRootContentItemResolver<EnumStructDefinitionResolvedContent>
    {
        public Result CatalogItem(
            ContentUnitScopeResolveContext unitContext,
            EnumStructDefinitionResolvedContent definition)
        {
            var context = new ItemResolveContext();
            
            throw new NotImplementedException();

            return Result.Success;
        }
    }
}
