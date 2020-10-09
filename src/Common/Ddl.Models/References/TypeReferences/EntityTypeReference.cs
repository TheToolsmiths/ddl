using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.References.TypeReferences
{
    public abstract class EntityTypeReference
    {
        protected EntityTypeReference(TypeIdentifierPath typeIdentifier, RootNamespacePath namespacePath)
        {
            this.TypeIdentifier = typeIdentifier;
            this.NamespacePath = namespacePath;
        }

        public TypeIdentifierPath TypeIdentifier { get; }

        public abstract EntityReference EntityReference { get; }

        public abstract TypeName EntityTypeName { get; }

        public RootNamespacePath NamespacePath { get; }

        public abstract override string ToString();
    }
}
