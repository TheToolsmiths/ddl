using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Namespaces
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

        public static NamespacePath Prepend(NamespacePath namespacePath, NamespacePath prefix)
        {
            if (namespacePath.IsRooted)
            {
                throw new ArgumentException(nameof(namespacePath));
            }

            if (prefix.IsEmpty)
            {
                return namespacePath;
            }

            var identifiers = new List<Identifier>();

            identifiers.AddRange(prefix.Identifiers);
            identifiers.AddRange(namespacePath.Identifiers);

            return new NamespacePath(identifiers, prefix.IsRooted);
        }
    }
}
