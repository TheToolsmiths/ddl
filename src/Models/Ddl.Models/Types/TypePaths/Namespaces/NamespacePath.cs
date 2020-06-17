using System;
using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces
{
    public class NamespacePath
    {
        private NamespacePath(IEnumerable<string> identifiers, bool isRooted)
        {
            this.IsRooted = isRooted;
            this.Identifiers = identifiers.ToList();
        }

        private NamespacePath(bool isRooted)
        {
            this.IsRooted = isRooted;
            this.Identifiers = Array.Empty<string>();
        }

        public bool IsRooted { get; }

        public IReadOnlyList<string> Identifiers { get; }

        public bool IsEmpty => this.Identifiers.Count == 0;

        public static NamespacePath Empty { get; } = new NamespacePath(isRooted: false);

        public static NamespacePath EmptyRoot { get; } = new NamespacePath(isRooted: true);

        public override string ToString()
        {
            return $"{(this.IsRooted ? TypeConstants.TypeSeparator : string.Empty)}" + string.Join(
                TypeConstants.TypeSeparator,
                this.Identifiers.Select(i => i.ToString()));
        }

        public static NamespacePath CreateFromIdentifiers(IEnumerable<string> identifiers)
        {
            return new NamespacePath(identifiers, isRooted: false);
        }

        public static NamespacePath CreateRootedFromIdentifiers(IEnumerable<string> identifiers)
        {
            return new NamespacePath(identifiers, isRooted: true);
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

            var identifiers = new List<string>();

            identifiers.AddRange(prefix.Identifiers);
            identifiers.AddRange(namespacePath.Identifiers);

            return new NamespacePath(identifiers, prefix.IsRooted);
        }
    }
}
