﻿using TheToolsmiths.Ddl.Models.References.ItemReferences;

namespace TheToolsmiths.Ddl.Models.Types.Resolution
{
    public class MatchImportResolution : TypeResolution
    {
        public MatchImportResolution(
            ItemReference importPathReference,
            TypeResolution importPathTypeResolution)
            : base(TypeResolutionKind.MatchImport)
        {
            this.ImportPathReference = importPathReference;
            this.ImportPathTypeResolution = importPathTypeResolution;
        }

        public ItemReference ImportPathReference { get; }

        public TypeResolution ImportPathTypeResolution { get; }
    }
}
