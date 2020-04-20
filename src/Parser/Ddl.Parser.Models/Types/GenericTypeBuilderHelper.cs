using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types
{
    internal static class GenericTypeBuilderHelper
    {
        public static (NamespacePath Namespace, Identifier Name) SplitNamespaceAndIdentifier(
            IReadOnlyList<Identifier> identifiers, bool isRooted)
        {
            if (identifiers == null
                || identifiers.Count == 0)
            {
                throw new ArgumentException(nameof(identifiers));
            }

            var name = identifiers[^1];

            NamespacePath namespacePath;
            if (identifiers.Count == 1)
            {
                namespacePath = isRooted ? NamespacePath.EmptyRoot : NamespacePath.Empty;
            }
            else
            {
                var range = identifiers.GetRange(..^1);
                namespacePath = isRooted ? NamespacePath.CreateRootedFromIdentifiers(range) : NamespacePath.CreateFromIdentifiers(range);
            }

            return (namespacePath, name);
        }
    }
}
