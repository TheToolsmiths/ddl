using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.FileContents
{
    public abstract class AttributableRootContentItem : IAttributableRootContentItem
    {
        protected AttributableRootContentItem(ITypeName typeName, IReadOnlyList<IAttributeUse> attributes)
        {
            this.TypeName = typeName;
            this.Attributes = attributes;
        }

        public abstract FileContentItemType ItemType { get; }

        public IReadOnlyList<IAttributeUse> Attributes { get; }

        public ITypeName TypeName { get; }
    }
}