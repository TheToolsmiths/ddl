using System;
using TheToolsmiths.Ddl.Models.ContentUnits.Items.ItemReferences;
using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Parser.Ast.Models.Enums;
using TheToolsmiths.Ddl.Parser.Build.Common.TypeHelpers;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class EnumDefinitionBuilder : IRootItemBuilder<EnumAstDefinition>
    {
        public RootItemBuildResult BuildItem(IRootItemBuildContext itemContext, EnumAstDefinition item)
        {
            var builder = new RootItemBuilder();

            CatalogEnumType(builder, item);

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

        private static void CatalogEnumType(RootItemBuilder builder, EnumAstDefinition definition)
        {
            var itemTypeName = TypeNameBuilder.CreateItemTypeName(definition.TypeName);

            var itemReference = new ItemReference(definition.ItemId);

            var rootType = new TypedItemReference(itemTypeName, itemReference);

            builder.RootType = itemTypeName;
            builder.RootTypeReference = rootType;
        }

        private static void CatalogVariants(RootItemBuilder builder, EnumAstDefinition definition)
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
                        CatalogVariant(builder, definition, constant);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(definitionItem));
                }
            }
        }

        private static void CatalogVariant(
            RootItemBuilder builder,
            EnumAstDefinition definition,
            EnumDefinitionConstantDefinition constant)
        {
            var subItemTypeName = TypeNameBuilder.CreateSubItemTypeName(builder.RootType, constant.Name);

            var subItemReference = new SubItemReference(definition.ItemId, constant.ItemId);

            var entry = new TypedSubItemReference(subItemTypeName, subItemReference);

            builder.SubItemTypesReferences.Add(entry);
        }
    }
}
