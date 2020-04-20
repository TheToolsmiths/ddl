using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.Identifiers
{
    public class NamespacePath
    {
        private NamespacePath(IEnumerable<Identifier> identifiers, bool isRooted)
        {
            this.IsRooted = isRooted;
            this.Identifiers = identifiers.ToList();
        }

        private NamespacePath(bool isRooted)
        {
            this.IsRooted = isRooted;
            this.Identifiers = Array.Empty<Identifier>();
        }

        public bool IsRooted { get; }

        public IReadOnlyList<Identifier> Identifiers { get; }

        public bool IsEmpty => this.Identifiers.Count == 0;

        public static NamespacePath Empty { get; } = new NamespacePath(false);

        public static NamespacePath EmptyRoot { get; } = new NamespacePath(true);

        public override string ToString()
        {
            return string.Join(TypeConstants.TypeSeparator, this.Identifiers.Select(i => i.ToString()));
        }

        public static NamespacePath CreateFromIdentifiers(IEnumerable<Identifier> identifiers)
        {
            return new NamespacePath(identifiers, false);
        }

        public static NamespacePath CreateRootedFromIdentifiers(IEnumerable<Identifier> identifiers)
        {
            return new NamespacePath(identifiers, true);
        }
    }
}
