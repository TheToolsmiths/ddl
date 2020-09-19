using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Structs
{
    public class StructDefinition : ITypedRootItem
    {
        public StructDefinition(
            ItemId itemId,
            TypedItemName typeName,
            StructDefinitionContent content,
            AttributeUseCollection attributes)
        {
            this.TypeName = typeName;
            this.Content = content;
            this.Attributes = attributes;
            this.ItemId = itemId;
        }

        public StructDefinition(
            TypedItemName typeName,
            StructDefinitionContent content,
            AttributeUseCollection attributes)
            : this(ItemId.CreateNew(), typeName, content, attributes)
        {
        }

        public StructDefinition(TypedItemName typeName, StructDefinitionContent content)
            : this(ItemId.CreateNew(), typeName, content, AttributeUseCollection.Empty)
        {
        }

        public TypedItemName TypeName { get; }

        public StructDefinitionContent Content { get; }

        public AttributeUseCollection Attributes { get; }

        public ItemType ItemType => CommonItemTypes.StructDefinition;

        public ItemId ItemId { get; }
    }
}
