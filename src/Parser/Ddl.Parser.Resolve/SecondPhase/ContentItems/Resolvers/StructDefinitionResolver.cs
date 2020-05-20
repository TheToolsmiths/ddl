using System;
using Ddl.Common;
using Ddl.Parser.Resolve.Models.FirstPhase.Items.Content;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers
{
    public class StructDefinitionResolver : IRootContentItemResolver<StructDefinitionResolvedContent>
    {
        private readonly StructDefinitionContentResolver contentResolver;

        public StructDefinitionResolver(StructDefinitionContentResolver contentResolver)
        {
            this.contentResolver = contentResolver;
        }

        public Result CatalogItem(
            ScopeItemResolveContext scopeContext,
            StructDefinitionResolvedContent definition)
        {
            var context = new ItemResolveContext();

            var content = definition.Content;

            var result = this.contentResolver.ResolveStructDefinitionContent(scopeContext, content);


            throw new NotImplementedException();

            return Result.Success;
        }
    }
}
