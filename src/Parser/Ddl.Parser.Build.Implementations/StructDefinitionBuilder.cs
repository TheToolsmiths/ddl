using System;
using TheToolsmiths.Ddl.Models.ContentUnits.Items.ItemReferences;
using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Build.Common.TypeHelpers;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class StructDefinitionBuilder : IRootItemBuilder<StructAstDefinition>
    {
        public RootItemBuildResult BuildItem(IRootItemBuildContext itemContext, StructAstDefinition item)
        {
            var builder = new RootItemBuilder();

            CatalogStructType(builder, item);

            CreateResolvedItem(builder, item);

            throw new NotImplementedException();

            //return builder.CreateSuccessResult();
        }

        private static void CreateResolvedItem(RootItemBuilder builder, StructAstDefinition structDefinition)
        {
            var itemReference = builder.RootTypeReference;
            var subItemReferences = builder.SubItemTypesReferences;

            //var item = new RootItemBase(itemReference, subItemReferences);

            throw new NotImplementedException();

            //builder.ResolvedItems.Add(item);
        }

        private static void CatalogStructType(RootItemBuilder builder, IAstTypedRootItem definition)
        {
            var itemTypeName = TypeNameBuilder.CreateItemTypeName(definition.TypeName);

            var itemReference = new ItemReference(definition.ItemId);

            var rootType = new TypedItemReference(itemTypeName, itemReference);

            builder.RootType = itemTypeName;
            builder.RootTypeReference = rootType;
        }
    }
}
