﻿using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items
{
    public abstract class AttributableRootItem : IAttributableRootItem
    {
        protected AttributableRootItem(ITypeName typeName, IReadOnlyList<IAttributeUse> attributes)
        {
            this.TypeName = typeName;
            this.Attributes = attributes;
        }

        public abstract ContentUnitItemType ItemType { get; }

        public IReadOnlyList<IAttributeUse> Attributes { get; }

        public ITypeName TypeName { get; }
    }
}