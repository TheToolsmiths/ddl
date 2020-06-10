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
    public class EnumDefinitionBuilder : IRootItemBuilder<EnumDefinition>
    {
        public RootItemBuildResult<EnumDefinition> BuildItem(IRootItemBuildContext unitContext, IAstRootItem item)
        {
            throw new NotImplementedException();
        }

        public Result BuildItem(
            IRootItemBuildContext unitContext,
            EnumAstDefinition item)
        {
            var context = new ItemResolveContext();

            CatalogEnumType(context, item);

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

        private static void CatalogEnumType(ItemResolveContext context, EnumAstDefinition definition)
        {
            var itemTypeName = TypeNameBuilder.CreateItemTypeName(definition.TypeName);

            var itemReference = new ItemReference(definition.ItemId);

            var rootType = new FirstPhaseItemTypeReference(itemTypeName, itemReference);

            context.RootType = itemTypeName;
            context.RootTypeReference = rootType;
        }

        private static void CatalogVariants(ItemResolveContext context, EnumAstDefinition definition)
        {
            if (definition.Content.IsEmpty)
            {
                return;
            }

            foreach (var definitionItem in definition.Content.Items)
            {
                switch (definitionItem)
                {
                    case EnumDefinitionConstantDefinition constant:
                        CatalogVariant(context, definition, constant);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(definitionItem));
                }
            }
        }

        private static void CatalogVariant(
            ItemResolveContext context,
            EnumAstDefinition definition,
            EnumDefinitionConstantDefinition constant)
        {
            var subItemTypeName = TypeNameBuilder.CreateSubItemTypeName(context.RootType, constant.Name);

            var subItemReference = new SubItemReference(definition.ItemId, constant.ItemId);

            var entry = new FirstPhaseSubItemTypeReference(subItemTypeName, subItemReference);

            context.SubItemTypesReferences.Add(entry);
        }
    }
}
