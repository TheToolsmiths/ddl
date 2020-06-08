using TheToolsmiths.Ddl.Parser.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Models.References.TypeReferences
{
    public class SubItemTypePathReference : EntityTypeReference
    {
        public SubItemTypePathReference(
            SubItemTypeName subItemTypeName,
            NamespacePath namespacePath,
            SubItemReference subItemReference,
            TypeIdentifierPath typeIdentifier)
            : base(typeIdentifier)
        {
            this.SubItemTypeName = subItemTypeName;
            this.NamespacePath = namespacePath;
            this.SubItemReference = subItemReference;
        }

        public SubItemReference SubItemReference { get; }

        public SubItemTypeName SubItemTypeName { get; }

        public override EntityReference EntityReference => this.SubItemReference;

        public NamespacePath NamespacePath { get; }

        public override string ToString()
        {
            return $"{this.SubItemReference} > {this.NamespacePath}::{this.SubItemTypeName}";
        }
    }
}
