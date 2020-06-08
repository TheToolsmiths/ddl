﻿namespace TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References
{
    public class SimpleReferencePathPart : TypeReferencePathPart
    {
        public SimpleReferencePathPart(string name)
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
