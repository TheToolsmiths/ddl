using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Models.ImportPaths;
using TheToolsmiths.Ddl.Parser.Build.Models.ItemReferences;
using TheToolsmiths.Ddl.Parser.Build.Models.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build.BuildPhase
{
    public class ContentUnitScopeBuildContext : IRootItemBuildContext
    {
        private ContentUnitScopeBuildContext(IReadOnlyList<FirstPhaseResolvedScopeProperty> properties)
        {
            this.Properties = properties;

            this.ResolvedScopes = new List<FirstPhaseResolvedScope>();
            this.ResolvedImportPaths = new List<FirstPhaseResolvedImportPath>();
            this.ResolvedItems = new List<FirstPhaseResolvedItem>();
        }

        public List<FirstPhaseResolvedItem> ResolvedItems { get; }

        public List<FirstPhaseResolvedScope> ResolvedScopes { get; }

        public List<FirstPhaseResolvedImportPath> ResolvedImportPaths { get; }

        public IReadOnlyList<FirstPhaseResolvedScopeProperty> Properties { get; }

        public FirstPhaseResolvedScope BuildResolvedScope()
        {
            return new FirstPhaseResolvedScope(this.ResolvedItems, this.ResolvedScopes, this.ResolvedImportPaths, this.Properties);
        }

        public static ContentUnitScopeBuildContext CreateRootContext()
        {
            return new ContentUnitScopeBuildContext(Array.Empty<FirstPhaseResolvedScopeProperty>());
        }

        public ContentUnitScopeBuildContext CreateChildContext()
        {
            return new ContentUnitScopeBuildContext(this.Properties);
        }

        public ContentUnitScopeBuildContext CreateScopeWithAdditionalProperties(
            IEnumerable<FirstPhaseResolvedScopeProperty> additionalProperties)
        {
            var properties = this.Properties.ToList();

            properties.AddRange(additionalProperties);

            return new ContentUnitScopeBuildContext(properties);
        }
    }
}
