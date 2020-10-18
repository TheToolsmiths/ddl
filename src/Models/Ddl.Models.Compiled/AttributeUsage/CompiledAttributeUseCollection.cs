using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public class CompiledAttributeUseCollection
    {
        private CompiledAttributeUseCollection(IReadOnlyList<ICompiledAttributeUse> items)
        {
            this.Items = items;
        }

        public static CompiledAttributeUseCollection Empty { get; } = Create(new List<ICompiledAttributeUse>());

        public bool HasAttributes => this.Items.Count > 0;

        public IReadOnlyList<ICompiledAttributeUse> Items { get; }

        public static CompiledAttributeUseCollection Create(IReadOnlyList<ICompiledAttributeUse> attributes)
        {
            return new CompiledAttributeUseCollection(attributes);
        }
    }
}
