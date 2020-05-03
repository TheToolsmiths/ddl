using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace Ddl.Resolve.Models.FirstPhase.TypePaths
{
    public class TypePathSimpleEntry : TypePathEntry
    {
        public TypePathSimpleEntry(Identifier identifier)
            : base(TypePathEntryKind.Simple)
        {
            this.Identifier = identifier;
        }

        public Identifier Identifier { get; }

        public override string ToString()
        {
            return $"{this.Identifier}";
        }
    }
}
