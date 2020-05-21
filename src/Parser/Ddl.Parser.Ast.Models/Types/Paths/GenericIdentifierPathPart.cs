using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths
{
    public class GenericIdentifierPathPart : TypeIdentifierPathPart
    {
        public GenericIdentifierPathPart(Identifier name, IReadOnlyList<ITypeIdentifier> genericParameters)
            : base(name)
        {
            this.GenericParameters = genericParameters;
        }

        public override TypeIdentifierPathPartKind PartKind => TypeIdentifierPathPartKind.Generic;

        public IReadOnlyList<ITypeIdentifier> GenericParameters { get; }

        public override string ToString()
        {
            return $"{this.Name}<{string.Join(',', this.GenericParameters.Select(gp => gp.ToString()))}>";
        }
    }
}
