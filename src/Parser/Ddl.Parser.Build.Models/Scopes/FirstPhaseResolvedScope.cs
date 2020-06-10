using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Build.Models.ImportPaths;
using TheToolsmiths.Ddl.Parser.Build.Models.ItemReferences;

namespace TheToolsmiths.Ddl.Parser.Build.Models.Scopes
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
