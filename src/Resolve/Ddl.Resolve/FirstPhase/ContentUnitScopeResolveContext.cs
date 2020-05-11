using System;
using System.Collections.Generic;
using System.Linq;
using Ddl.Resolve.Models.FirstPhase.ImportPaths;
using Ddl.Resolve.Models.FirstPhase.Items;
using Ddl.Resolve.Models.FirstPhase.Scopes;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class ContentUnitScopeResolveContext
    {
        private ContentUnitScopeResolveContext(FirstPhaseNamespacePath scopeNamespace, IReadOnlyList<FirstPhaseResolvedScopeProperty> properties)
        {
            this.ScopeNamespace = scopeNamespace;
            this.Properties = properties;

            this.ResolvedScopes = new List<FirstPhaseResolvedScope>();
            this.ResolvedImportPaths = new List<FirstPhaseResolvedImportPath>();
            this.ResolvedItems = new List<FirstPhaseResolvedItem>();
        }

        public FirstPhaseNamespacePath ScopeNamespace { get; }

        public List<FirstPhaseResolvedItem> ResolvedItems { get; }

        public List<FirstPhaseResolvedScope> ResolvedScopes { get; }

        public List<FirstPhaseResolvedImportPath> ResolvedImportPaths { get; }

        public IReadOnlyList<FirstPhaseResolvedScopeProperty> Properties { get; }

        public FirstPhaseResolvedScope BuildResolvedScope()
        {
            return new FirstPhaseResolvedScope(this.ResolvedItems, this.ResolvedScopes, this.Properties);
        }

        public static ContentUnitScopeResolveContext CreateRootContext(FirstPhaseNamespacePath rootNamespace)
        {
            return new ContentUnitScopeResolveContext(rootNamespace, Array.Empty<FirstPhaseResolvedScopeProperty>());
        }

        public ContentUnitScopeResolveContext CreateScopeWithAdditionalProperties(
            IReadOnlyList<FirstPhaseResolvedScopeProperty> additionalProperties)
        {
            var properties = this.Properties.ToList();

            properties.AddRange(additionalProperties);

            return new ContentUnitScopeResolveContext(this.ScopeNamespace, properties);
        }
    }
}
