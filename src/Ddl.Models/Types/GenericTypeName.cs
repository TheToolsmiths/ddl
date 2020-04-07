using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Types
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

        public TypeNameType Type => TypeNameType.SimpleType;

        public override string ToString()
        {
            string parameterList = string.Join(
                TypeConstants.TypeParameterSpacedSeparator,
                this.TypeArgumentList.Select(i => i.ToString()));

            return string.Concat(this.Name.ToString(), TypeConstants.TypeParameterListBegin, parameterList, TypeConstants.TypeParameterListEnd);
        }
    }
}
