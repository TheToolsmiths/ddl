using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Ast.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Types.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.Types.TypePaths.Identifiers
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
