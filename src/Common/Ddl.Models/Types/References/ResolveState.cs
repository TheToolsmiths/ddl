﻿using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Types.References
{
    public class ResolveState
    {
        public ResolveState(IReadOnlyList<TypeReference> builtReferences)
        {
            this.BuiltReferences = builtReferences;
        }

        public IReadOnlyList<TypeReference> BuiltReferences { get; }
    }
}