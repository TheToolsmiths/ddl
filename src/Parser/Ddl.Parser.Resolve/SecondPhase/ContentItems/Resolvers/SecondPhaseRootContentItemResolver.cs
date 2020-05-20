using System;
using Ddl.Common;
using Ddl.Parser.Resolve.Models.FirstPhase.Items;
using Ddl.Parser.Resolve.Models.FirstPhase.Items.Content;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers
{
    public class SecondPhaseRootContentItemResolver
    {
        private readonly ContentUnitItemResolverProvider resolverProvider;

        public SecondPhaseRootContentItemResolver(ContentUnitItemResolverProvider resolverProvider)
        {
            this.resolverProvider = resolverProvider;
        }

        public Result ResolveContentItem(ScopeItemResolveContext context, FirstPhaseResolvedItem contentItem)
        {

            var foo = contentItem.Content;

            var result = foo switch
            {
                EnumDefinitionResolvedContent enumDefinition => this.resolverProvider.CreateEnumDefinitionResolver()
                    .CatalogItem(context, enumDefinition),

                EnumStructDefinitionResolvedContent enumStructDefinition => this.resolverProvider.CreateEnumStructDefinitionResolver()
                        .CatalogItem(context, enumStructDefinition),

                StructDefinitionResolvedContent structDefinition => this.resolverProvider.CreateStructDefinitionResolver()
                        .CatalogItem(context, structDefinition),

                _ => throw new ArgumentOutOfRangeException(nameof(contentItem))
            };

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return Result.Success;
        }
    }
}
