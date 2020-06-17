using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Models.Types.Names
{
    public class GenericTypeNameIdentifier : TypeNameIdentifier
    {
        public GenericTypeNameIdentifier(string name, IReadOnlyList<GenericTypeNameParameter> genericParameters)
            : base(name)
        {
            this.GenericParameters = genericParameters;
        }

        public override TypeNameIdentifierKind IdentifierKind => TypeNameIdentifierKind.Generic;

        public IReadOnlyList<GenericTypeNameParameter> GenericParameters { get; }

        public override string ToString()
        {
            return $"{this.Name}<{string.Join(',', this.GenericParameters.Select(gp => gp.ToString()))}>";
        }
    }
}
