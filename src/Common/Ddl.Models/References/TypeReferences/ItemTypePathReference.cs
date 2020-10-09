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
            RootNamespacePath namespacePath,
            ItemReference itemReference,
            TypeIdentifierPath typeIdentifier)
            : base(typeIdentifier, namespacePath)
        {
            this.TypedItemName = typedItemName;
            this.ItemReference = itemReference;
        }

        public TypedItemName TypedItemName { get; }

        public ItemReference ItemReference { get; }

        public override EntityReference EntityReference => this.ItemReference;

        public override TypeName EntityTypeName => this.TypedItemName;

        public override string ToString()
        {
            return $"{this.ItemReference} > {this.TypeIdentifier}";
        }
    }
}
