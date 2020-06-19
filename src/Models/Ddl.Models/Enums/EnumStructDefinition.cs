using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumStructDefinition : IRootItem
    {
        public EnumStructDefinition(TypedItemName typeName, IReadOnlyList<EnumStructVariantDefinition> variants)
        {
            this.TypeName = typeName;
            this.Variants = variants;
        }

        public TypedItemName TypeName { get; }

        public IReadOnlyList<EnumStructVariantDefinition> Variants { get; }
    }
}
