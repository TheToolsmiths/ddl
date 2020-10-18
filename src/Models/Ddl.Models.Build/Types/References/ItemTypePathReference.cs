using TheToolsmiths.Ddl.Models.Build.Items.References;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Models.Build.Types.References
{
    public class ItemTypePathReference : EntityTypeReference
    {
        public ItemTypePathReference(ItemTypeName typeName, RootNamespacePath namespacePath, ItemReference itemReference)
            : base(namespacePath)
        {
            this.TypeName = typeName;
            this.ItemReference = itemReference;
        }

        public ItemTypeName TypeName { get; }

        public ItemReference ItemReference { get; }

        public override EntityReference EntityReference => this.ItemReference;

        public override TypeName EntityTypeName => this.TypeName;

        public override string ToString()
        {
            return $"{this.ItemReference} > {this.TypeName}";
        }
    }
}
