using TheToolsmiths.Ddl.Parser.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Models.References.TypeReferences
{
    public class ItemTypePathReference : EntityTypeReference
    {
        public ItemTypePathReference(
            ItemTypeName itemTypeName,
            NamespacePath namespacePath,
            ItemReference itemReference,
            TypeIdentifierPath typeIdentifier)
            : base(typeIdentifier)
        {
            this.ItemTypeName = itemTypeName;
            this.NamespacePath = namespacePath;
            this.ItemReference = itemReference;
        }

        public ItemTypeName ItemTypeName { get; }

        public NamespacePath NamespacePath { get; }

        public ItemReference ItemReference { get; }

        public override EntityReference EntityReference => this.ItemReference;

        public override string ToString()
        {
            return $"{this.ItemReference} > {this.NamespacePath}::{this.ItemTypeName}";
        }
    }
}
