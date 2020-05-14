using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase.ImportPaths;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    public class ScopeTypeImportPathLayer
    {
        private ScopeTypeImportPathLayer(IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
        {
            this.ImportPaths = importPaths;
        }

        public IReadOnlyList<FirstPhaseResolvedImportPath> ImportPaths { get; }

        public static ScopeTypeImportPathLayer FromImportPaths(IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
        {
            return new ScopeTypeImportPathLayer(importPaths);
        }
    }
}
