using System;
using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class NamespaceIdentifier
    {
        public NamespaceIdentifier(IEnumerable<string> identifiers)
        {
            Identifiers = identifiers.ToList();
        }

        private NamespaceIdentifier()
        {
            Identifiers = Array.Empty<string>();
        }

        public IReadOnlyList<string> Identifiers { get; }

        public static NamespaceIdentifier Empty { get; } = new NamespaceIdentifier();
    }
}
