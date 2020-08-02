using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumDefinition : ITypedRootItem
    {
        public EnumDefinition(TypedItemName typeName, IReadOnlyList<EnumConstantDefinition> constants)
        {
            this.TypeName = typeName;
            this.Constants = constants;
            this.ItemId = ItemId.CreateNew();
        }

        public ItemType ItemType => CommonItemTypes.EnumDefinition;

        public ItemId ItemId { get; }

        public TypedItemName TypeName { get; }

        public IReadOnlyList<EnumConstantDefinition> Constants { get; }
    }
}
