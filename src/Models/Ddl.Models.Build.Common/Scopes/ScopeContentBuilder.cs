using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ImportPaths;
using TheToolsmiths.Ddl.Models.Build.Items;

namespace TheToolsmiths.Ddl.Models.Build.Scopes
{
    public class ScopeContentBuilder
    {
        public ScopeContent Build()
        {
            var imports = ImportStatementCollection.Create(this.Imports);
            return new ScopeContent(this.Items, this.Scopes, imports);
        }

        public List<ImportStatement> Imports { get; } = new List<ImportStatement>();

        public List<IRootItem> Items { get; } = new List<IRootItem>();

        public List<IRootScope> Scopes { get; } = new List<IRootScope>();
    }
}
