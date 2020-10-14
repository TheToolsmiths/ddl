using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items.ItemReferences;
using TheToolsmiths.Ddl.Models.Build.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Build.Structs;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Contexts;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Implementations
{
    internal class StructDefinitionIndexer : IRootItemIndexer<StructDefinition>
    {
        public RootItemIndexResult IndexItem(IRootItemIndexContext itemContext, StructDefinition item)
        {
            var builder = new RootItemIndexResultBuilder();

            var itemReference = new ItemReference(item.ItemId);
            builder.RootTypeReference = new TypedItemReference(item.TypeName, itemReference);

            return builder.CreateSuccessResult();
        }
    }
}
