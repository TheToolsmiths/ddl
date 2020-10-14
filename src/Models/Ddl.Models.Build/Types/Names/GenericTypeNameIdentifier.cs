using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Build.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Types.Names
{
    public class GenericTypeNameIdentifier : TypeNameIdentifier
    {
        public GenericTypeNameIdentifier(string name, IReadOnlyList<GenericTypeNameParameter> genericParameters)
            : base(name)
        {
            this.GenericParameters = genericParameters;
        }

        public override PathPartKind IdentifierKind => PathPartKind.Generic;

        public IReadOnlyList<GenericTypeNameParameter> GenericParameters { get; }

        public override string ToString()
        {
            return PathHelpers.ToGenericName(this.Name, this.GenericParameters);
        }

        public static TypeNameIdentifier Create(string typeName, params string[] genericParameters)
        {
            var parameters = genericParameters.Select(p => new GenericTypeNameParameter(p)).ToList();

            return new GenericTypeNameIdentifier(typeName, parameters);
        }
    }
}
