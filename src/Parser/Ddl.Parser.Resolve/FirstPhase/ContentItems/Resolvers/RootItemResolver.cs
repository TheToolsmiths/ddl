using System;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.Enums;
using TheToolsmiths.Ddl.Parser.Ast.Models.Imports;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class RootItemResolver
    {
        private readonly ContentUnitEntityResolverProvider resolverProvider;

        public RootItemResolver(ContentUnitEntityResolverProvider resolverProvider)
        {
            this.resolverProvider = resolverProvider;
        }

        public Result ResolveItem(ContentUnitScopeResolveContext context, IRootItem item)
        {
            var result = item switch
            {
                EnumDefinition enumDefinition => this.resolverProvider.CreateEnumDefinitionResolver()
                    .CatalogItem(context, enumDefinition),

                EnumStructDefinition enumStructDefinition => this.resolverProvider.CreateEnumStructDefinitionResolver()
                    .CatalogItem(context, enumStructDefinition),

                ImportStatement importStatement => this.resolverProvider.CreateImportStatementResolver()
                    .CatalogItem(context, importStatement),

                StructDefinition structDefinition => this.resolverProvider.CreateStructDefinitionResolver()
                    .CatalogItem(context, structDefinition),

                _ => throw new ArgumentOutOfRangeException(nameof(item))
            };

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return Result.Success;
        }
    }
}
