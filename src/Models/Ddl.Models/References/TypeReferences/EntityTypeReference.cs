using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Identifiers;

namespace TheToolsmiths.Ddl.Models.References.TypeReferences
{
    public abstract class EntityTypeReference
    {
        protected EntityTypeReference(TypeIdentifierPath typeIdentifier)
        {
            this.TypeIdentifier = typeIdentifier;
        }

        public abstract override string ToString();

        public TypeIdentifierPath TypeIdentifier { get; }

        public abstract EntityReference EntityReference { get; }
    }
}
