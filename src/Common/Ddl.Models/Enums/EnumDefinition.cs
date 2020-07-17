using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumDefinition : IRootItem
    {
        public EnumDefinition(TypedItemName typeName, IReadOnlyList<EnumConstantDefinition> constants)
        {
            this.TypeName = typeName;
            this.Constants = constants;
        }

        public TypedItemName TypeName { get; }

        public IReadOnlyList<EnumConstantDefinition> Constants { get; }
    }
}
