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
            IReadOnlyList<ImportStatement> importPaths)
        {
            this.Items = items;
            this.Scopes = scopes;
            this.ImportPaths = importPaths;
        }

        public IReadOnlyList<IRootItem> Items { get; }

        public IReadOnlyList<IRootScope> Scopes { get; }

        public IReadOnlyList<ImportStatement> ImportPaths { get; }

        public static ScopeContent Empty { get; } = CreateEmpty();

        private static ScopeContent CreateEmpty()
        {
            return new ScopeContent(
                new List<IRootItem>(),
                new List<IRootScope>(),
                new List<ImportStatement>());
        }

        public static ScopeContent Create(
            IEnumerable<IRootItem> items,
            IEnumerable<IRootScope> scopes,
            IEnumerable<ImportStatement> importPaths)
        {
            return new ScopeContent(items.ToList(), scopes.ToList(), importPaths.ToList());
        }
    }
}
