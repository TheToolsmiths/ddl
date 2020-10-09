﻿using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.Identifiers
{
    public class GenericIdentifierPathPart : TypeIdentifierPathPart
    {
        public GenericIdentifierPathPart(
            string name,
            int genericParametersCount)
            : base(name)
        {
            this.GenericParametersCount = genericParametersCount;
        }

        public override PathPartKind PartKind => PathPartKind.Generic;

        public int GenericParametersCount { get; }

        public override string ToString()
        {
            return PathHelpers.ToGenericIdentifier(this.Name, this.GenericParametersCount);
        }
    }
}
