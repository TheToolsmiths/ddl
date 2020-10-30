using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Compiled.Items
{
    public interface ISubItemOwner : ICompiledItem
    {
        public IReadOnlyList<ICompiledSubItem> SubItems { get; }
    }
}
