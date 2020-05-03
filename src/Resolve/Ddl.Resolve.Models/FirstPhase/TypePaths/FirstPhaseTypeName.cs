using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace Ddl.Resolve.Models.FirstPhase.TypePaths
{
    public class FirstPhaseTypeName
    {
        public FirstPhaseTypeName(IReadOnlyList<TypePathEntry> entries)
        {
            this.Entries = entries;
        }

        public IReadOnlyList<TypePathEntry> Entries { get; }

        public static FirstPhaseTypeName FromTypeName(ITypeName typeName)
        {
            var entries = new List<TypePathEntry>();

            TypePathEntry entry = typeName switch
            {
                GenericTypeName genericTypeName => new TypePathGenericEntry(
                    genericTypeName.Name,
                    genericTypeName.TypeArgumentList.Count),

                SimpleTypeName simpleTypeName => new TypePathSimpleEntry(simpleTypeName.Name),

                _ => throw new ArgumentOutOfRangeException(nameof(typeName))
            };

            entries.Add(entry);

            return new FirstPhaseTypeName(entries);
        }

        public FirstPhaseTypeName AppendEntry(Identifier identifier)
        {
            var newEntries = this.Entries.ToList();

            newEntries.Add(new TypePathSimpleEntry(identifier));

            return new FirstPhaseTypeName(newEntries);
        }

        public override string ToString()
        {
            return string.Join("::", this.Entries.Select(e => e.ToString()));
        }
    }
}
