﻿using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Types.References.Resolve
{
    public class ResolveState
    {
        public ResolveState(IReadOnlyList<ReferencedTypeResolveState> referencedTypes)
        {
            this.ReferencedTypes = referencedTypes;
        }

        public IReadOnlyList<ReferencedTypeResolveState> ReferencedTypes { get; }
    }
}
