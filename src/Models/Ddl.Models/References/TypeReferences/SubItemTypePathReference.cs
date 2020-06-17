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
            : base(typeIdentifier)
        {
            this.TypedSubItemName = typedSubItemName;
            this.NamespacePath = namespacePath;
            this.SubItemReference = subItemReference;
        }

        public SubItemReference SubItemReference { get; }

        public TypedSubItemName TypedSubItemName { get; }

        public override EntityReference EntityReference => this.SubItemReference;

        public NamespacePath NamespacePath { get; }

        public override string ToString()
        {
            return $"{this.SubItemReference} > {this.NamespacePath}::{this.TypedSubItemName}";
        }
    }
}
