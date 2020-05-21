﻿using Ddl.Parser.Resolve.Models.Common.ItemReferences;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths;

namespace Ddl.Parser.Resolve.Models.FirstPhase.Items
{
    public class FirstPhaseItemTypeReference
    {
        public FirstPhaseItemTypeReference(TypeReferencePath typePath, ItemReference itemReference)
        {
            this.TypePath = typePath;
            this.ItemReference = itemReference;
        }

        public TypeReferencePath TypePath { get; }

        public ItemReference ItemReference { get; }
    }
}
