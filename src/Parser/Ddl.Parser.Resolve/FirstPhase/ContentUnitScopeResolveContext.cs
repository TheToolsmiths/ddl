using System;
using System.Collections.Generic;
using System.Linq;
using Ddl.Parser.Resolve.Models.FirstPhase.ImportPaths;
using Ddl.Parser.Resolve.Models.FirstPhase.Items;
using Ddl.Parser.Resolve.Models.FirstPhase.Scopes;
using TheToolsmiths.Ddl.Parser.Models.Types.Namespaces;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class ContentUnitScopeResolveContext
    {
        private ContentUnitScopeResolveContext(NamespacePath scopeNamespace, IReadOnlyList<FirstPhaseResolvedScopeProperty> properties)
        {
            this.ScopeNamespace = scopeNamespace;
            this.Properties = properties;

            this.ResolvedScopes = new List<FirstPhaseResolvedScope>();
            this.ResolvedImportPaths = new List<FirstPhaseResolvedImportPath>();
            this.ResolvedItems = new List<FirstPhaseResolvedItem>();
        }

        public NamespacePath ScopeNamespace { get; }

        public List<FirstPhaseResolvedItem> ResolvedItems { get; }

        public List<FirstPhaseResolvedScope> ResolvedScopes { get; }

        public List<FirstPhaseResolvedImportPath> ResolvedImportPaths { get; }

        public IReadOnlyList<FirstPhaseResolvedScopeProperty> Properties { get; }

        public FirstPhaseResolvedScope BuildResolvedScope()
        {
            return new FirstPhaseResolvedScope(this.ResolvedItems, this.ResolvedScopes, this.ResolvedImportPaths, this.Properties);
        }

        public static ContentUnitScopeResolveContext CreateRootContext(NamespacePath rootNamespace)
        {
            return new ContentUnitScopeResolveContext(rootNamespace, Array.Empty<FirstPhaseResolvedScopeProperty>());
        }

        public ContentUnitScopeResolveContext CreateChildContext()
        {
            return new ContentUnitScopeResolveContext(this.ScopeNamespace, this.Properties);
        }

        public ContentUnitScopeResolveContext CreateScopeWithAdditionalProperties(
            IEnumerable<FirstPhaseResolvedScopeProperty> additionalProperties)
        {
            var properties = this.Properties.ToList();

            properties.AddRange(additionalProperties);

            return new ContentUnitScopeResolveContext(this.ScopeNamespace, properties);
        }
    }
}
