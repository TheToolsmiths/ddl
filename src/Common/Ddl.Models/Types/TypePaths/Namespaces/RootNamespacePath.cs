using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces
{
    public partial class RootNamespacePath : NamespacePath
    {
        private RootNamespacePath(ImmutableArray<string> identifiers)
            : base(identifiers, true)
        {
        }

        private RootNamespacePath()
            : base(true)
        {
        }

        public static RootNamespacePath EmptyRoot { get; } = new RootNamespacePath();

        public new static RootNamespacePath CreateFromIdentifiers(IEnumerable<string> identifiers)
        {
            return new RootNamespacePath(ImmutableArray.CreateRange(identifiers));
        }

        public static RootNamespacePath Append(RootNamespacePath namespacePath, string identifier)
        {
            var builder = ImmutableArray.CreateBuilder<string>(namespacePath.Identifiers.Length + 1);

            builder.AddRange(namespacePath.Identifiers);
            builder.Add(identifier);

            return new RootNamespacePath(builder.MoveToImmutable());
        }

        public new static RootNamespacePath Append(NamespacePath namespacePath, string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
            {
                throw new ArgumentNullException(nameof(identifier));
            }

            var builder = ImmutableArray.CreateBuilder<string>(namespacePath.Identifiers.Length + 1);

            builder.AddRange(namespacePath.Identifiers);
            builder.Add(identifier);

            return new RootNamespacePath(builder.MoveToImmutable());
        }
    }
}
