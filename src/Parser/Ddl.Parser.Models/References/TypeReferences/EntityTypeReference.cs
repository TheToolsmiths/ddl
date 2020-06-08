using TheToolsmiths.Ddl.Parser.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.References.TypeReferences
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
