using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.Identifiers
{
    public class NamespacePath
    {
        public NamespacePath(IEnumerable<Identifier> identifiers)
        {
            this.Identifiers = identifiers.ToList();
        }

        private NamespacePath()
        {
            this.Identifiers = Array.Empty<Identifier>();
        }

        public IReadOnlyList<Identifier> Identifiers { get; }

        public bool IsEmpty => this.Identifiers.Count == 0;

        public static NamespacePath Empty { get; } = new NamespacePath();

        public override string ToString()
        {
            return string.Join(TypeConstants.TypeSeparator, this.Identifiers.Select(i => i.ToString()));
        }
    }
}
