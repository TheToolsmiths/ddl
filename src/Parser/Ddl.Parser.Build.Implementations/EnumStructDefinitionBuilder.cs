using System;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.Enums;
using TheToolsmiths.Ddl.Parser.Build.Common.TypeHelpers;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Models.ItemReferences;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Parser.Models.Enums;
using TheToolsmiths.Ddl.Parser.Models.References.ItemReferences;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class EnumStructDefinitionBuilder : IRootItemBuilder<EnumStructDefinition>
    {
        public RootItemBuildResult<EnumStructDefinition> BuildItem(IRootItemBuildContext unitContext, IAstRootItem item)
        {
            throw new NotImplementedException();
        }

        public Result BuildItem(IRootItemBuildContext unitContext, EnumStructAstDefinition item)
        {
            var context = new ItemResolveContext();

            CatalogEnumStructType(context, item);

            CatalogVariants(context, item);

            CreateResolvedItem(unitContext, context);

            return Result.Success;
        }

        private static void CreateResolvedItem(
            IRootItemBuildContext unitContext,
            ItemResolveContext context)
        {
            var itemReference = context.RootTypeReference;
            var subItemReferences = context.SubItemTypesReferences;

            var item = new FirstPhaseResolvedItem(itemReference, subItemReferences);

            unitContext.ResolvedItems.Add(item);
        }

        private static void CatalogEnumStructType(ItemResolveContext context, EnumStructAstDefinition definition)
        {
            var itemTypeName = TypeNameBuilder.CreateItemTypeName(definition.TypeName);

            var itemReference = new ItemReference(definition.ItemId);

            var rootType = new FirstPhaseItemTypeReference(itemTypeName, itemReference);

            context.RootType = itemTypeName;
            context.RootTypeReference = rootType;
        }

        private static void CatalogVariants(ItemResolveContext context, EnumStructAstDefinition definition)
        {
            if (definition.Content.IsEmpty)
            {
                return;
            }

            foreach (var definitionItem in definition.Content.Items)
            {
                switch (definitionItem)
                {
                    case EnumStructVariantDefinition variant:
                        CatalogVariant(context, definition, variant);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(definitionItem));
                }
            }
        }

        private static void CatalogVariant(
            ItemResolveContext context,
            EnumStructAstDefinition definition,
            EnumStructVariantDefinition variant)
        {
            var subItemTypeName = TypeNameBuilder.CreateSubItemTypeName(context.RootType, variant.Name);

            var subItemReference = new SubItemReference(definition.ItemId, variant.ItemId);

            var entry = new FirstPhaseSubItemTypeReference(subItemTypeName, subItemReference);

            context.SubItemTypesReferences.Add(entry);
        }
    }
}
