using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.Items;
using Ddl.Resolve.Models.FirstPhase.Items.Content;
using Ddl.Resolve.Models.FirstPhase.TypePaths;
using Ddl.Resolve.Models.FirstPhase.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Structs;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class StructDefinitionResolver : IRootContentItemResolver<StructDefinition>
    {
        public Result CatalogItem(ContentUnitScopeResolveContext unitContext, StructDefinition definition)
        {
            var context = new ItemResolveContext();

            CatalogStructType(context, definition);

            CreateResolvedItem(unitContext, context);

            return Result.Success;
        }

        private static void CreateResolvedItem(ContentUnitScopeResolveContext unitContext, ItemResolveContext context)
        {
            var content = new StructDefinitionResolvedContent();
            
            var itemReference = context.RootTypeReference;
            var subItemReferences = context.SubItemTypesReferences;

            var item = new FirstPhaseResolvedItem(content, itemReference, subItemReferences);

            unitContext.ResolvedItems.Add(item);
        }

        private static void CatalogStructType(ItemResolveContext context, StructDefinition definition)
        {
            var typePath = FirstPhaseTypeName.FromTypeName(definition.TypeName);

            var rootType = new FirstPhaseTypePathItemReference(typePath, definition.ItemId);
            context.RootType = typePath;
            context.RootTypeReference = rootType;
        }
    }
}
