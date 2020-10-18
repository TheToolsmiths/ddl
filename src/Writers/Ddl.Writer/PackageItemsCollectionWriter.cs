using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Models.Compiled.Package.Items;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer
{
    public class PackageItemsWriter
    {
        public Result WriteItemsCollection(IRootItemWriterContext context, PackageItemsCollection itemsCollection)
        {
            context.Writer.WriteStartArray();

            var result = this.WriteItems(context, itemsCollection.Items);

            if (result.IsError)
            {
                throw new System.NotImplementedException();
            }

            context.Writer.WriteEndArray();

            return Result.Success;
        }

        private Result WriteItems(IRootItemWriterContext context, IReadOnlyList<PackageItem> items)
        {
            foreach (var packageItem in items)
            {
                var result = this.WriteItem(context, packageItem);

                if (result.IsError)
                {
                    throw new System.NotImplementedException();
                }
            }

            return Result.Success;
        }

        private Result WriteItem(IRootItemWriterContext context, PackageItem packageItem)
        {
            context.Writer.WriteStartObject();

            this.WriteItemInfo(context, packageItem);

            if (packageItem.Item is INamedRootItem typedItem)
            {
                this.WriteItemTypeInfo(context, typedItem);
            }

            if (packageItem.Item is IAttributableRootItem attributableItem)
            {
                this.WriteItemAttributes(context, attributableItem);
            }

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private void WriteItemInfo(IRootItemWriterContext context, PackageItem packageItem)
        {
            context.Writer.WriteNumber("id", packageItem.ItemId.ToInt());

            context.Writer.WriteString("type", packageItem.ItemType.ToString());
        }

        private void WriteItemTypeInfo(IRootItemWriterContext context, INamedRootItem namedItem)
        {
            context.Writer.WritePropertyName("typeName");

            throw new NotImplementedException();

            //context.CommonWriters.WriteTypeNameResolution(typedItem.TypeNameResolution);
        }

        private void WriteItemAttributes(IRootItemWriterContext context, IAttributableRootItem attributableItem)
        {
            context.Writer.WritePropertyName("typeName");

            context.CommonWriters.WriteAttributes(attributableItem.Attributes);
        }
    }
}
