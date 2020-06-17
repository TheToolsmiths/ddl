using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names
{
    public class GenericTypeName : TypeName
    {
        public GenericTypeName(Identifier name, IReadOnlyList<Identifier> typeParameters)
            : base(name)
        {
            this.TypeParameters = typeParameters;
        }

        public IReadOnlyList<Identifier> TypeParameters { get; }

        public override string ToString()
        {
            string parameterList = string.Join(
                TypeConstants.TypeParameterSpacedSeparator,
                this.TypeParameters.Select(i => i.ToString()));

            return string.Concat(
                this.Name.ToString(),
                TypeConstants.TypeParameterListBegin,
                parameterList,
                TypeConstants.TypeParameterListEnd);
        }
    }
}
