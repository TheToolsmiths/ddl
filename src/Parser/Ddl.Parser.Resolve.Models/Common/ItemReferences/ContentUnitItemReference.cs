﻿using Ddl.Common.Models;

namespace Ddl.Parser.Resolve.Models.Common.ItemReferences
{
    public class ContentUnitItemReference : ContentUnitEntityReference
    {
        public ContentUnitItemReference(ContentUnitId contentUnitId, ContentUnitItemId itemId)
            : base(contentUnitId)
        {
            this.ItemId = itemId;
        }

        public ContentUnitItemId ItemId { get; }

        public static ContentUnitItemReference Create(in ContentUnitId contentUnitId, ItemReference itemReference)
        {
            return new ContentUnitItemReference(contentUnitId, itemReference.ItemId);
        }

        public override string ToString()
        {
            return $"[{this.ContentUnitId}] ({this.ItemId})";
        }
    }
}
