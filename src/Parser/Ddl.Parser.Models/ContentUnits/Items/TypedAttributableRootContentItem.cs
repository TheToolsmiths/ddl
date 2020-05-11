using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items
{
    public abstract class TypedAttributableRootContentItem : TypedRootContentItem, ITypedAttributableRootContentItem
    {
        protected TypedAttributableRootContentItem(ITypeName typeName, IReadOnlyList<IAttributeUse> attributes)
        : base(typeName)
        {
            this.Attributes = attributes;
        }

        public IReadOnlyList<IAttributeUse> Attributes { get; }
    }
}
