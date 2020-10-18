using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Namespaces.Paths
{
    public class NamespacePath
    {
        protected NamespacePath(ImmutableArray<string> identifiers, bool isRooted)
        {
            this.IsRooted = isRooted;
            this.Identifiers = identifiers;

            if (this.Identifiers.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Some path identifiers are not valid", nameof(identifiers));
            }
        }

        protected NamespacePath(bool isRooted)
        {
            this.IsRooted = isRooted;
            this.Identifiers = ImmutableArray.Create<string>();
        }

        public bool IsRooted { get; }

        public ImmutableArray<string> Identifiers { get; }

        public bool IsEmpty => this.Identifiers.Length == 0;

        public static NamespacePath Empty { get; } = new NamespacePath(false);

        public override string ToString()
        {
            return PathHelpers.ToQualifiedString(this.IsRooted, this.Identifiers);
        }

        public static NamespacePath CreateFromIdentifiers(IEnumerable<string> identifiers)
        {
            return new NamespacePath(ImmutableArray.CreateRange(identifiers), false);
        }

        protected static NamespacePath CreateFromArray(ImmutableArray<string> identifiers)
        {
            return new NamespacePath(identifiers, false);
        }

        public static RootNamespacePath CreateRootedFromIdentifiers(IEnumerable<string> identifiers)
        {
            return RootNamespacePath.CreateFromIdentifiers(identifiers);
        }

        public static NamespacePath Append(NamespacePath namespacePath, string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
            {
                throw new ArgumentNullException(nameof(identifier));
            }

            var builder = ImmutableArray.CreateBuilder<string>(namespacePath.Identifiers.Length + 1);

            builder.AddRange(namespacePath.Identifiers);
            builder.Add(identifier);

            return new NamespacePath(builder.MoveToImmutable(), namespacePath.IsRooted);
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

            var builder = ImmutableArray.CreateBuilder<string>(namespacePath.Identifiers.Length + prefix.Identifiers.Length);

            builder.AddRange(prefix.Identifiers);
            builder.AddRange(namespacePath.Identifiers);

            return new NamespacePath(builder.MoveToImmutable(), prefix.IsRooted);
        }
    }
}
