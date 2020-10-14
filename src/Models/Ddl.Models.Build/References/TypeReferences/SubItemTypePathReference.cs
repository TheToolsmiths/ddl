using TheToolsmiths.Ddl.Models.Build.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Build.References.TypeReferences
{
    public class SubItemTypePathReference : EntityTypeReference
    {
        public SubItemTypePathReference(
            TypedSubItemName typedSubItemName,
            RootNamespacePath namespacePath,
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
