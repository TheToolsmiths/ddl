﻿using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace Ddl.Resolve.Models.FirstPhase.ImportPaths
{
    public class ResolvedImportIdentifierAlias : ResolvedImportItem
    {
        public ResolvedImportIdentifierAlias(Identifier identifier, Identifier aliasIdentifier)
        {
            this.Identifier = identifier;
            this.AliasIdentifier = aliasIdentifier;
        }

        public Identifier Identifier { get; }

        public Identifier AliasIdentifier { get; }

        public override ResolvedImportedItemKind ItemKind => ResolvedImportedItemKind.IdentifierAlias;
    }
}
