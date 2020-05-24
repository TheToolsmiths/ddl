using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names
{
    public class GenericTypeName : ITypeName
    {
        public GenericTypeName(Identifier name, IReadOnlyList<Identifier> typeArgumentList)
        {
            this.Name = name;
            this.TypeArgumentList = typeArgumentList;
        }

        public Identifier Name { get; }

        public IReadOnlyList<Identifier> TypeArgumentList { get; }

        public bool IsGeneric => false;

        public TypeNameKind Kind => TypeNameKind.SimpleType;

        public override string ToString()
        {
            string parameterList = string.Join(
                TypeConstants.TypeParameterSpacedSeparator,
                this.TypeArgumentList.Select(i => i.ToString()));

            return string.Concat(this.Name.ToString(), TypeConstants.TypeParameterListBegin, parameterList, TypeConstants.TypeParameterListEnd);
        }
    }
}
