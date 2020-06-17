using System;
using TheToolsmiths.Ddl.Models.ContentUnits.Items.ItemReferences;
using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Parser.Ast.Models.Enums;
using TheToolsmiths.Ddl.Parser.Build.Common.TypeHelpers;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class EnumStructDefinitionBuilder : IRootItemBuilder<EnumStructAstDefinition>
    {
        public RootItemBuildResult BuildItem(IRootItemBuildContext itemContext, EnumStructAstDefinition item)
        {
            var builder = new RootItemBuilder();

            CatalogEnumStructType(builder, item);

            CatalogVariants(builder, item);

            CreateResolvedItem(builder);

            throw new NotImplementedException();

            //return builder.CreateSuccessResult();
        }

        private static void CreateResolvedItem(RootItemBuilder builder)
        {
            var itemReference = builder.RootTypeReference;
            var subItemReferences = builder.SubItemTypesReferences;

            //var item = new RootItemBase(itemReference, subItemReferences);
            
            throw new NotImplementedException();

            //builder.ResolvedItems.Add(item);
        }

        private static void CatalogEnumStructType(RootItemBuilder builder, EnumStructAstDefinition definition)
        {
            var itemTypeName = TypeNameBuilder.CreateItemTypeName(definition.TypeName);

            var itemReference = new ItemReference(definition.ItemId);

            var rootType = new TypedItemReference(itemTypeName, itemReference);

            builder.RootType = itemTypeName;
            builder.RootTypeReference = rootType;
        }

        private static void CatalogVariants(RootItemBuilder builder, EnumStructAstDefinition definition)
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
                        CatalogVariant(builder, definition, variant);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(definitionItem));
                }
            }
        }

        private static void CatalogVariant(
            RootItemBuilder builder,
            EnumStructAstDefinition definition,
            EnumStructVariantDefinition variant)
        {
            var subItemTypeName = TypeNameBuilder.CreateSubItemTypeName(builder.RootType, variant.Name);

            var subItemReference = new SubItemReference(definition.ItemId, variant.ItemId);

            var entry = new TypedSubItemReference(subItemTypeName, subItemReference);

            builder.SubItemTypesReferences.Add(entry);
        }
    }
}
