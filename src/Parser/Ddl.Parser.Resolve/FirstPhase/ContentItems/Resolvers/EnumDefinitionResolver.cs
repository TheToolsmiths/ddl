using System;
using Ddl.Common;
using Ddl.Parser.Resolve.Models.Common.ItemReferences;
using Ddl.Parser.Resolve.Models.FirstPhase.Items;
using Ddl.Parser.Resolve.Models.FirstPhase.Items.Content;
using TheToolsmiths.Ddl.Parser.Models.Enums;
using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class EnumDefinitionResolver : IRootContentItemResolver<EnumDefinition>
    {
        public Result CatalogItem(
            ContentUnitScopeResolveContext unitContext,
            EnumDefinition item)
        {
            var context = new ItemResolveContext();

            CatalogEnumType(context, item);

            CatalogVariants(context, item);

            CreateResolvedItem(unitContext, context);

            return Result.Success;
        }

        private static void CreateResolvedItem(
            ContentUnitScopeResolveContext unitContext,
            ItemResolveContext context)
        {
            var content = new EnumDefinitionResolvedContent();

            var itemReference = context.RootTypeReference;
            var subItemReferences = context.SubItemTypesReferences;

            var item = new FirstPhaseResolvedItem(content, itemReference, subItemReferences);

            unitContext.ResolvedItems.Add(item);
        }

        private static void CatalogEnumType(ItemResolveContext context, EnumDefinition definition)
        {
            var typePath = TypeReferencePathBuilder.FromTypeName(definition.TypeName);

            var itemReference = new ItemReference(definition.ItemId);

            var rootType = new FirstPhaseItemTypeReference(typePath, itemReference);
            context.RootType = typePath;
            context.RootTypeReference = rootType;
        }

        private static void CatalogVariants(ItemResolveContext context, EnumDefinition definition)
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
            EnumDefinition definition,
            EnumDefinitionConstantDefinition constant)
        {
            var enumConstantTypePath = TypeReferencePathBuilder.AppendIdentifier(context.RootType, constant.Name);

            var subItemReference = new SubItemReference(definition.ItemId, constant.ItemId);

            var entry = new FirstPhaseSubItemTypeReference(enumConstantTypePath, subItemReference);

            context.SubItemTypesReferences.Add(entry);
        }
    }
}
