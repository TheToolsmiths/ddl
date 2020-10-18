using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Compiled.Structs.Content
{
    public class CompiledStructContent
    {
        public CompiledStructContent(IReadOnlyList<ICompiledStructItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<ICompiledStructItem> Items { get; }
    }
}
