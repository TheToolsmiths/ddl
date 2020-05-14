using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase.ImportPaths;
using Ddl.Resolve.Models.FirstPhase.Items;

namespace Ddl.Resolve.Models.FirstPhase.Scopes
{
    public class FirstPhaseResolvedScope
    {
        public FirstPhaseResolvedScope(
            IReadOnlyList<FirstPhaseResolvedItem> items,
            IReadOnlyList<FirstPhaseResolvedScope> scopes,
            IReadOnlyList<FirstPhaseResolvedImportPath> importPaths,
            IReadOnlyList<FirstPhaseResolvedScopeProperty> properties)
        {
            this.Scopes = scopes;
            this.ImportPaths = importPaths;
            this.Properties = properties;
            this.Items = items;
        }

        public IReadOnlyList<FirstPhaseResolvedScopeProperty> Properties { get; }

        public IReadOnlyList<FirstPhaseResolvedScope> Scopes { get; }

        public IReadOnlyList<FirstPhaseResolvedImportPath> ImportPaths { get; }

        public IReadOnlyList<FirstPhaseResolvedItem> Items { get; }
    }
}
