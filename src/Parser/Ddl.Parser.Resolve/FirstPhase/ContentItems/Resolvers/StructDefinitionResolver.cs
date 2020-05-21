using Ddl.Common;
using Ddl.Parser.Resolve.Models.Common.ItemReferences;
using Ddl.Parser.Resolve.Models.FirstPhase.Items;
using Ddl.Parser.Resolve.Models.FirstPhase.Items.Content;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class StructDefinitionResolver : IRootContentItemResolver<StructDefinition>
    {
        public Result CatalogItem(ContentUnitScopeResolveContext unitContext, StructDefinition item)
        {
            var context = new ItemResolveContext();

            CatalogStructType(context, item);

            CreateResolvedItem(unitContext, context, item);

            return Result.Success;
        }

        private static void CreateResolvedItem(
            ContentUnitScopeResolveContext unitContext,
            ItemResolveContext context,
            StructDefinition structDefinition)
        {
            var content = new StructDefinitionResolvedContent(structDefinition.Content);

            var itemReference = context.RootTypeReference;
            var subItemReferences = context.SubItemTypesReferences;

            var item = new FirstPhaseResolvedItem(content, itemReference, subItemReferences);

            unitContext.ResolvedItems.Add(item);
        }

        private static void CatalogStructType(ItemResolveContext context, ITypedRootItem definition)
        {
            var typePath = TypeReferencePathBuilder.FromTypeName(definition.TypeName);

            var itemReference = new ItemReference(definition.ItemId);

            var rootType = new FirstPhaseItemTypeReference(typePath, itemReference);

            context.RootType = typePath;
            context.RootTypeReference = rootType;
        }
    }
}
