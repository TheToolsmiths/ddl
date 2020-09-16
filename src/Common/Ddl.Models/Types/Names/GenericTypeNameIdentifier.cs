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

        public override TypeNameKind IdentifierKind => TypeNameKind.Generic;

        public IReadOnlyList<GenericTypeNameParameter> GenericParameters { get; }

        public override string ToString()
        {
            return $"{this.Name}<{string.Join(',', this.GenericParameters.Select(gp => gp.ToString()))}>";
        }

        public static TypeNameIdentifier Create(string typeName, params string[] genericParameters)
        {
            var parameters = genericParameters.Select(p => new GenericTypeNameParameter(p)).ToList();

            return new GenericTypeNameIdentifier(typeName, parameters);
        }
    }
}
