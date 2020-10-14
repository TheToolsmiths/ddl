using TheToolsmiths.Ddl.Models.Build.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Build.References.TypeReferences
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
