using System.Collections.Generic;
using System.Linq;

using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.ImportPaths;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Scopes
{
    public class ScopeContent
    {
        public ScopeContent(
            IReadOnlyList<IRootItem> items,
            IReadOnlyList<IRootScope> scopes,
            ImportStatementCollection imports)
        {
            this.Items = items;
            this.Scopes = scopes;
            this.Imports = imports;
        }

        public IReadOnlyList<IRootItem> Items { get; }

        public IReadOnlyList<IRootScope> Scopes { get; }

        public ImportStatementCollection Imports { get; }

        public static ScopeContent Empty { get; } = CreateEmpty();

        private static ScopeContent CreateEmpty()
        {
            return new ScopeContent(
                new List<IRootItem>(),
                new List<IRootScope>(),
                ImportStatementCollection.Empty);
        }

        public static ScopeContent Create(
            IEnumerable<IRootItem> items,
            IEnumerable<IRootScope> scopes,
            IEnumerable<ImportStatement> importPaths)
        {
            return new ScopeContent(items.ToList(), scopes.ToList(), ImportStatementCollection.Create(importPaths.ToList()));
        }

        public static ScopeContent Create(IReadOnlyList<IRootScope> scopes)
        {
            return new ScopeContent(new List<IRootItem>(), scopes, ImportStatementCollection.Empty);
        }
    }
}
