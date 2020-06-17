using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Structs
{
    public class StructDefinition : IRootItem
    {
        public StructDefinition(TypedItemName typeName, StructDefinitionContent content)
        {
            this.TypeName = typeName;
            this.Content = content;
        }

        public TypedItemName TypeName { get; }

        public StructDefinitionContent Content { get; }
    }
}
