using System;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.Enums;
using TheToolsmiths.Ddl.Parser.Models.Imports;
using TheToolsmiths.Ddl.Parser.Models.Structs;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class FirstPhaseRootContentItemResolver
    {
        private readonly ContentUnitItemResolverProvider resolverProvider;

        public FirstPhaseRootContentItemResolver(ContentUnitItemResolverProvider resolverProvider)
        {
            this.resolverProvider = resolverProvider;
        }

        public Result ResolveContentItem(ContentUnitScopeResolveContext context, IRootContentItem contentItem)
        {
            var result = contentItem switch
            {
                RootScope rootScope => this.resolverProvider.CreateRootScopeResolver().CatalogItem(context, rootScope),

                EnumDefinition enumDefinition => this.resolverProvider.CreateEnumDefinitionResolver()
                    .CatalogItem(context, enumDefinition),

                EnumStructDefinition enumStructDefinition => this.resolverProvider.CreateEnumStructDefinitionResolver()
                    .CatalogItem(context, enumStructDefinition),

                ImportStatement importStatement => this.resolverProvider.CreateImportStatementResolver()
                    .CatalogItem(context, importStatement),

                StructDefinition structDefinition => this.resolverProvider.CreateStructDefinitionResolver()
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
