﻿using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types.Paths
{
    public class SimpleReferencePathPart : TypeReferencePathPart
    {
        public SimpleReferencePathPart(Identifier name)
            : base(name)
        {
        }

        public override TypeReferencePathPartKind PartKind => TypeReferencePathPartKind.Simple;

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
