using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Namespaces.Paths
{
    public class RelativeNamespacePath
    {
        private RelativeNamespacePath(ImmutableArray<string> identifiers)
        {
            this.Identifiers = identifiers;

            if (this.Identifiers.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Some path identifiers are not valid", nameof(identifiers));
            }
        }

        public ImmutableArray<string> Identifiers { get; }

        public bool IsEmpty => this.Identifiers.Length == 0;

        public static RelativeNamespacePath Empty { get; } = new RelativeNamespacePath(ImmutableArray<string>.Empty);

        public override string ToString()
        {
            return PathHelpers.ToQualifiedString(false, this.Identifiers);
        }

        public static RelativeNamespacePath CreateFromIdentifiers(IEnumerable<string> identifiers)
        {
            return new RelativeNamespacePath(ImmutableArray.CreateRange(identifiers));
        }
    }
}
