﻿using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Packager.Items;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Builders
{
    public class ContentUnitPackageItemsBuilder
    {
        public ContentUnitPackageItemsBuilder()
        {
            this.Items = new List<PackageItem>();
            this.TypedItems = new List<PackageTypedItem>();
        }

        public List<PackageItem> Items { get; }

        public List<PackageTypedItem> TypedItems { get; }

        public void AddItem(PackageTypedItem item)
        {
            this.TypedItems.Add(item);
        }

        public void AddItem(PackageItem item)
        {
            this.Items.Add(item);
        }

        public PackageItemsCollection Build()
        {
            return new PackageItemsCollection(this.Items, this.TypedItems);
        }
    }
}
