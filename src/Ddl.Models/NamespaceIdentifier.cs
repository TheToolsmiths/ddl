using System;
using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Models
{
    public class NamespaceIdentifier
    {
        public NamespaceIdentifier(IEnumerable<Identifier> identifiers)
        {
            Identifiers = identifiers.ToList();
        }

        private NamespaceIdentifier()
        {
            Identifiers = Array.Empty<Identifier>();
        }

        public IReadOnlyList<Identifier> Identifiers { get; }

        public static NamespaceIdentifier Empty { get; } = new NamespaceIdentifier();
    }
}
