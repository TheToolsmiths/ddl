using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Identifiers
{
    public class GenericIdentifierPathPart : TypeIdentifierPathPart
    {
        public GenericIdentifierPathPart(Identifier name, IReadOnlyList<TypeIdentifierPath> genericParameters)
            : base(name)
        {
            this.GenericParameters = genericParameters;
        }

        public override TypeIdentifierPathPartKind PartKind => TypeIdentifierPathPartKind.Generic;

        public IReadOnlyList<TypeIdentifierPath> GenericParameters { get; }

        public override string ToString()
        {
            return $"{this.Name}<{string.Join(',', this.GenericParameters.Select(gp => gp.ToString()))}>";
        }
    }
}
