using System;
using System.Collections.Immutable;
using System.Linq;

using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths
{
    public partial class QualifiedNamespacePath
    {
        private QualifiedNamespacePath(ImmutableArray<string> identifiers)
        {
            this.Identifiers = identifiers;

            if (this.Identifiers.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Some path identifiers are not valid", nameof(identifiers));
            }
        }

        public ImmutableArray<string> Identifiers { get; }

        public bool IsEmpty => this.Identifiers.Length == 0;

        public static QualifiedNamespacePath Root { get; } = new QualifiedNamespacePath(ImmutableArray<string>.Empty);

        public override string ToString()
        {
            return PathHelpers.ToQualifiedString(true, this.Identifiers);
        }
    }
}
