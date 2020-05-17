using System;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.Items;
using Ddl.Resolve.Models.FirstPhase.Items.Content;
using Ddl.Resolve.Models.ItemReferences;
using Ddl.Resolve.Models.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Enums;
using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class EnumStructDefinitionResolver : IRootContentItemResolver<EnumStructDefinition>
    {
        public Result CatalogItem(ContentUnitScopeResolveContext unitContext, EnumStructDefinition item)
        {
            var context = new ItemResolveContext();

            CatalogEnumStructType(context, item);

            CatalogVariants(context, item);

            CreateResolvedItem(unitContext, context);

            return Result.Success;
        }

        private static void CreateResolvedItem(
            ContentUnitScopeResolveContext unitContext,
            ItemResolveContext context)
        {
            var content = new EnumStructDefinitionResolvedContent();

            var itemReference = context.RootTypeReference;
            var subItemReferences = context.SubItemTypesReferences;

            var item = new FirstPhaseResolvedItem(content, itemReference, subItemReferences);

            unitContext.ResolvedItems.Add(item);
        }

        private static void CatalogEnumStructType(ItemResolveContext context, EnumStructDefinition definition)
        {
            var typePath = TypeReferencePathBuilder.FromTypeName(definition.TypeName);

            var itemReference = new ItemReference(definition.ItemId);

            var rootType = new FirstPhaseItemTypeReference(typePath, itemReference);

            context.RootType = typePath;
            context.RootTypeReference = rootType;
        }

        private static void CatalogVariants(ItemResolveContext context, EnumStructDefinition definition)
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
            EnumStructDefinition definition,
            EnumStructVariantDefinition variant)
        {
            var enumVariantTypePath = TypeReferencePathBuilder.AppendIdentifier(context.RootType, variant.Name);

            var subItemReference = new SubItemReference(definition.ItemId, variant.ItemId);

            var entry = new FirstPhaseSubItemTypeReference(enumVariantTypePath, subItemReference);

            context.SubItemTypesReferences.Add(entry);
        }
    }
}
