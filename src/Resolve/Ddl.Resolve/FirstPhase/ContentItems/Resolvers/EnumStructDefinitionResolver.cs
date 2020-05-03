using System;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.Items;
using Ddl.Resolve.Models.FirstPhase.Items.Content;
using Ddl.Resolve.Models.FirstPhase.TypePaths;
using Ddl.Resolve.Models.FirstPhase.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Enums;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class EnumStructDefinitionResolver : IRootContentItemResolver<EnumStructDefinition>
    {
        public Result CatalogItem(ContentUnitScopeResolveContext unitContext, EnumStructDefinition definition)
        {
            var context = new ItemResolveContext();

            CatalogEnumStructType(context, definition);

            CatalogVariants(context, definition);

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
            var typePath = FirstPhaseTypeName.FromTypeName(definition.TypeName);

            var rootType = new FirstPhaseTypePathItemReference(typePath, definition.ItemId);
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
            var enumVariantTypePath = context.RootType.AppendEntry(variant.Name);

            var entry = new FirstPhaseTypePathSubItemReference(enumVariantTypePath, definition.ItemId, variant.ItemId);

            context.SubItemTypesReferences.Add(entry);
        }
    }
}
