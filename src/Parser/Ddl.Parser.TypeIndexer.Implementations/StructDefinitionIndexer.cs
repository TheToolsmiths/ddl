using TheToolsmiths.Ddl.Models.Build.Indexing.Items;
using TheToolsmiths.Ddl.Models.Build.Items.References;
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

            builder.ItemType = new ItemTypeIndexEntry(item.TypeName, itemReference);

            return builder.CreateSuccessResult();
        }
    }
}
