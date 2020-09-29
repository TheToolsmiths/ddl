﻿using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.References
{
    public class SimpleReferencePathPart : TypeReferencePathPart
    {
        public SimpleReferencePathPart(string name)
            : base(name)
        {
        }

        public override PathPartKind PartKind => PathPartKind.Simple;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
