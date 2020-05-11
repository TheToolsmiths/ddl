﻿using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace Ddl.Resolve.Models.FirstPhase.ImportPaths
{
    public class ResolvedImportPathItem : ResolvedImportItem
    {
        public ResolvedImportPathItem(ResolvedImportItem childItem, Identifier pathIdentifier)
        {
            this.ChildItem = childItem;
            this.PathIdentifier = pathIdentifier;
        }

        public ResolvedImportItem ChildItem { get; }

        public Identifier PathIdentifier { get; }

        public override ResolvedImportedItemKind ItemKind => ResolvedImportedItemKind.PathItem;
    }
}