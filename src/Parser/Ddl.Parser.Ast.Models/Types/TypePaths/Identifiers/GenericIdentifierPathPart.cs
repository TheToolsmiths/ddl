using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers
{
    public class GenericIdentifierPathPart : TypeIdentifierPathPart
    {
        public GenericIdentifierPathPart(Identifier name, IReadOnlyList<IGenericParameterTypeIdentifier> genericParameters)
            : base(name)
        {
            this.GenericParameters = genericParameters;
        }

        public IReadOnlyList<IGenericParameterTypeIdentifier> GenericParameters { get; }

        public override string ToString()
        {
            return $"{this.Name}<{string.Join(',', this.GenericParameters.Select(gp => gp.ToString()))}>";
        }
    }
}
