using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.References.TypeReferences
{
    public class SubItemTypePathReference : EntityTypeReference
    {
        public SubItemTypePathReference(
            TypedSubItemName typedSubItemName,
            NamespacePath namespacePath,
            SubItemReference subItemReference,
            TypeIdentifierPath typeIdentifier)
            : base(typeIdentifier, namespacePath)
        {
            this.TypedSubItemName = typedSubItemName;
            this.SubItemReference = subItemReference;
        }

        public SubItemReference SubItemReference { get; }

        public TypedSubItemName TypedSubItemName { get; }

        public override EntityReference EntityReference => this.SubItemReference;

        public override TypeName EntityTypeName => this.TypedSubItemName;

        public override string ToString()
        {
            return $"{this.SubItemReference} > {this.TypeIdentifier}";
        }
    }
}
