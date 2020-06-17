using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.References.TypeReferences
{
    public class ItemTypePathReference : EntityTypeReference
    {
        public ItemTypePathReference(
            TypedItemName typedItemName,
            NamespacePath namespacePath,
            ItemReference itemReference,
            TypeIdentifierPath typeIdentifier)
            : base(typeIdentifier)
        {
            this.TypedItemName = typedItemName;
            this.NamespacePath = namespacePath;
            this.ItemReference = itemReference;
        }

        public TypedItemName TypedItemName { get; }

        public NamespacePath NamespacePath { get; }

        public ItemReference ItemReference { get; }

        public override EntityReference EntityReference => this.ItemReference;

        public override string ToString()
        {
            return $"{this.ItemReference} > {this.NamespacePath}::{this.TypedItemName}";
        }
    }
}
