using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.Identifiers
{
    public class NamespaceIdentifier
    {
        public NamespaceIdentifier(IEnumerable<Identifier> identifiers)
        {
            this.Identifiers = identifiers.ToList();
        }

        private NamespaceIdentifier()
        {
            this.Identifiers = Array.Empty<Identifier>();
        }

        public IReadOnlyList<Identifier> Identifiers { get; }

        public bool IsEmpty => this.Identifiers.Count == 0;

        public static NamespaceIdentifier Empty { get; } = new NamespaceIdentifier();

        public override string ToString()
        {
            return string.Join(TypeConstants.TypeSeparator, this.Identifiers.Select(i => i.ToString()).ToString());
        }
    }
}
