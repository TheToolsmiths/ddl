using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumDefinition : IRootItem
    {
        public EnumDefinition(TypedItemName typeName, IReadOnlyList<EnumConstantDefinition> variants)
        {
            this.TypeName = typeName;
            this.Variants = variants;
        }

        public TypedItemName TypeName { get; }

        public IReadOnlyList<EnumConstantDefinition> Variants { get; }
    }

    public struct EnumConstantDefinition
    {
        public EnumConstantDefinition(string name, LiteralValue value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; }

        public LiteralValue Value { get; }
    }
}
