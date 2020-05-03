using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace Ddl.Resolve.Models.FirstPhase.TypePaths
{
    public class FirstPhaseNamespacePath
    {
        private FirstPhaseNamespacePath(IReadOnlyList<Identifier> identifiers)
        {
            this.Identifiers = identifiers;
        }

        public IReadOnlyList<Identifier> Identifiers { get; }

        public override string ToString()
        {
            return string.Join(TypeConstants.TypeSeparator, this.Identifiers.Select(i => i.ToString()));
        }

        public static FirstPhaseNamespacePath FromIdentifiers(IEnumerable<Identifier> identifiers)
        {
            var list = identifiers.ToList();

            return new FirstPhaseNamespacePath(list);
        }

        public FirstPhaseTypeName Append(FirstPhaseTypeName typeName)
        {
            var entries = new List<TypePathEntry>();

            entries.AddRange(this.Identifiers.Select(i => new TypePathSimpleEntry(i)));

            entries.AddRange(typeName.Entries);

            return new FirstPhaseTypeName(entries);
        }
    }
}
