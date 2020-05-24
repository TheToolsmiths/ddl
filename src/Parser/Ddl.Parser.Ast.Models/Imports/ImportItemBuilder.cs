using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Imports
{
    public static class ImportItemBuilder
    {
        public static ImportItem CreateFromIdentifierListWithGroup(IReadOnlyList<Identifier> identifiers, ImportGroup importGroup)
        {
            if (identifiers.Count == 0)
            {
                return importGroup;
            }

            ImportPathItem? child = null;

            for (int i = identifiers.Count - 1; i >= 0; i--)
            {
                var identifier = identifiers[i];

                child = child == null ? new ImportPathItem(importGroup, identifier) : new ImportPathItem(child, identifier);
            }

            return child ?? throw new ArgumentException(nameof(identifiers));
        }

        public static ImportItem CreateFromIdentifierList(IReadOnlyList<Identifier> identifiers)
        {
            if (identifiers.Count == 0)
            {
                throw new ArgumentException(nameof(identifiers));
            }

            ImportItem child = ImportIdentifier.Create(identifiers[^1]);

            foreach (var identifier in identifiers.GetRange(..^1).Reverse())
            {
                child = new ImportPathItem(child, identifier);
            }

            return child;
        }

        public static ImportItem CreateAliasFromIdentifierList(List<Identifier> identifiers, Identifier aliasIdentifier)
        {
            if (identifiers.Count == 0)
            {
                throw new ArgumentException(nameof(identifiers));
            }

            ImportItem child = ImportIdentifierAlias.Create(identifiers[^1], aliasIdentifier);

            foreach (var identifier in identifiers.GetRange(..^1).Reverse())
            {
                child = new ImportPathItem(child, identifier);
            }

            return child;
        }
    }
}
