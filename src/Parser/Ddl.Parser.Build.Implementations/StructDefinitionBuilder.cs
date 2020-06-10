using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Build.Common.TypeHelpers;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Models.ItemReferences;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Parser.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Structs;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class StructDefinitionBuilder : IRootItemBuilder<StructDefinition>
    {
        public RootItemBuildResult<StructDefinition> BuildItem(IRootItemBuildContext unitContext, IAstRootItem item)
        {
            throw new System.NotImplementedException();
        }

        public Result BuildItem(IRootItemBuildContext unitContext, StructAstDefinition item)
        {
            var context = new ItemResolveContext();

            CatalogStructType(context, item);

            CreateResolvedItem(unitContext, context, item);

            return Result.Success;
        }

        private static void CreateResolvedItem(
            IRootItemBuildContext unitContext,
            ItemResolveContext context,
            StructAstDefinition structDefinition)
        {
            //var content = new StructDefinitionResolvedContent(structDefinition.Content);

            var itemReference = context.RootTypeReference;
            var subItemReferences = context.SubItemTypesReferences;

            var item = new FirstPhaseResolvedItem(itemReference, subItemReferences);

            unitContext.ResolvedItems.Add(item);
        }

        private static void CatalogStructType(ItemResolveContext context, IAstTypedRootItem definition)
        {
            var itemTypeName = TypeNameBuilder.CreateItemTypeName(definition.TypeName);

            var itemReference = new ItemReference(definition.ItemId);

            var rootType = new FirstPhaseItemTypeReference(itemTypeName, itemReference);

            context.RootType = itemTypeName;
            context.RootTypeReference = rootType;
        }
    }
}
