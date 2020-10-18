using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Compiled.Structs.Content
{
    public class CompiledStructScope : ICompiledStructItem
    {
        public CompiledStructScope(IReadOnlyList<ICompiledStructItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<ICompiledStructItem> Items { get; }

        public CompiledStructItemKind ItemKind => CompiledStructItemKind.Scope;
    }
}
