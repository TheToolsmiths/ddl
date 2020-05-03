using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase.Items;

namespace Ddl.Resolve.Models.FirstPhase.Scopes
{
    public class FirstPhaseResolvedScope
    {
        public FirstPhaseResolvedScope(
            IReadOnlyList<FirstPhaseResolvedItem> resolvedItems,
            IReadOnlyList<FirstPhaseResolvedScope> resolvedScopes,
            IReadOnlyList<FirstPhaseResolvedScopeProperty> properties)
        {
            this.ResolvedScopes = resolvedScopes;
            this.Properties = properties;
            this.ResolvedItems = resolvedItems;
        }

        public IReadOnlyList<FirstPhaseResolvedScopeProperty> Properties { get; }

        public IReadOnlyList<FirstPhaseResolvedScope> ResolvedScopes { get; }

        public IReadOnlyList<FirstPhaseResolvedItem> ResolvedItems { get; }
    }
}
