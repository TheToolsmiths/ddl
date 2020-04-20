using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.FileContents
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