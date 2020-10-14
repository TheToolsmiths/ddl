﻿using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.Types.References.Resolve;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.References.Builders
{
    public partial class TypeReferenceBuilder
    {
        internal class Context
        {
            public Context()
            {
                this.BuiltReferences = new List<ReferencedTypeResolveState>();
                this.ResolveState = new ResolveState(this.BuiltReferences);
            }

            public List<ReferencedTypeResolveState> BuiltReferences { get; }

            public ResolveState ResolveState { get; }
        }
    }
}
