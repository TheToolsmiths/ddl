using System;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.Items;
using Ddl.Resolve.Models.FirstPhase.Items.Content;
using Ddl.Resolve.Models.FirstPhase.TypePaths;
using Ddl.Resolve.Models.FirstPhase.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Enums;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class EnumDefinitionResolver : IRootContentItemResolver<EnumDefinition>
    {
        public Result CatalogItem(
            ContentUnitScopeResolveContext unitContext,
            EnumDefinition definition)
        {
            var context = new ItemResolveContext();

            CatalogEnumType(context, definition);

            CatalogVariants(context, definition);

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
            var typePath = FirstPhaseTypeName.FromTypeName(definition.TypeName);

            var rootType = new FirstPhaseTypePathItemReference(typePath, definition.ItemId);
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
            var enumConstantTypePath = context.RootTypeReference.TypeName.AppendEntry(constant.Name);

            var entry = new FirstPhaseTypePathSubItemReference(enumConstantTypePath, definition.ItemId, constant.ItemId);

            context.SubItemTypesReferences.Add(entry);
        }
    }
}
