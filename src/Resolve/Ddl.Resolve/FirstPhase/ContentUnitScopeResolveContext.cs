using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase.Items;
using Ddl.Resolve.Models.FirstPhase.Scopes;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class ContentUnitScopeResolveContext
    {
        public ContentUnitScopeResolveContext(IReadOnlyList<FirstPhaseResolvedScopeProperty> properties)
        {
            this.Properties = properties;
        }

        public ContentUnitScopeResolveContext()
        {
            this.Properties = new List<FirstPhaseResolvedScopeProperty>();
        }

        public List<FirstPhaseResolvedItem> ResolvedItems { get; } = new List<FirstPhaseResolvedItem>();

        public List<FirstPhaseResolvedScope> ResolvedScopes { get; } = new List<FirstPhaseResolvedScope>();

        public IReadOnlyList<FirstPhaseResolvedScopeProperty> Properties { get; }

        public FirstPhaseResolvedScope BuildResolvedScope()
        {
            return new FirstPhaseResolvedScope(this.ResolvedItems, this.ResolvedScopes, this.Properties);
        }
    }
}
