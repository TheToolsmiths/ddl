using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Compiled.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Scopes
{
    public class CompiledScopeContent
    {
        public CompiledScopeContent(
            IReadOnlyList<ICompiledItem> items,
            IReadOnlyList<ICompiledScope> scopes)
        {
            this.Items = items;
            this.Scopes = scopes;
        }

        public IReadOnlyList<ICompiledItem> Items { get; }

        public IReadOnlyList<ICompiledScope> Scopes { get; }

        public static CompiledScopeContent Empty { get; } = CreateEmpty();

        private static CompiledScopeContent CreateEmpty()
        {
            return new CompiledScopeContent(
                new List<ICompiledItem>(),
                new List<ICompiledScope>());
        }

        public static CompiledScopeContent Create(
            IEnumerable<ICompiledItem> items,
            IEnumerable<ICompiledScope> scopes)
        {
            return new CompiledScopeContent(items.ToList(), scopes.ToList());
        }

        public static CompiledScopeContent Create(IReadOnlyList<ICompiledScope> scopes)
        {
            return new CompiledScopeContent(new List<ICompiledItem>(), scopes);
        }
    }
}
