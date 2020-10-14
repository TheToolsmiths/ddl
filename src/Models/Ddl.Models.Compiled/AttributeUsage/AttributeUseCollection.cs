using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public class AttributeUseCollection
    {
        private AttributeUseCollection(IReadOnlyList<IAttributeUse> items)
        {
            this.Items = items;
        }

        public static AttributeUseCollection Empty { get; } = Create(new List<IAttributeUse>());

        public bool HasAttributes => this.Items.Count > 0;

        public IReadOnlyList<IAttributeUse> Items { get; }

        public static AttributeUseCollection Create(IReadOnlyList<IAttributeUse> attributes)
        {
            return new AttributeUseCollection(attributes);
        }
    }
}
