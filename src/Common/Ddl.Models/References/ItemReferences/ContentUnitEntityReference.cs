﻿using TheToolsmiths.Ddl.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Models.References.ItemReferences
{
    public abstract class ContentUnitEntityReference
    {
        protected ContentUnitEntityReference(ContentUnitId contentUnitId)
        {
            this.ContentUnitId = contentUnitId;
        }

        public ContentUnitId ContentUnitId { get; }

        public abstract override string ToString();
    }
}