using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.TypePaths.Identifiers
{
    public class ResolvedGenericIdentifierPathPart : ResolvedTypeIdentifierPathPart
    {
        public ResolvedGenericIdentifierPathPart(Identifier name, IReadOnlyList<ResolvedTypeIdentifierPath> genericParameters)
            : base(name)
        {
            this.GenericParameters = genericParameters;
        }

        public override ResolvedTypeIdentifierPathPartKind PartKind => ResolvedTypeIdentifierPathPartKind.Generic;

        public IReadOnlyList<ResolvedTypeIdentifierPath> GenericParameters { get; }

        public override string ToString()
        {
            return $"{this.Name}<{string.Join(',', this.GenericParameters.Select(gp => gp.ToString()))}>";
        }
    }
}
