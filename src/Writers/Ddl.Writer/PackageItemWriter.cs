using System;

using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Models.Compiled.Package.Items;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer
{
    internal class PackageItemWriter
    {
        private readonly CompiledItemDefinitionWriter itemDefinitionWriter;
        private readonly CompiledSubItemDefinitionWriter subItemDefinitionWriter;

        public PackageItemWriter(CompiledItemDefinitionWriter itemDefinitionWriter, CompiledSubItemDefinitionWriter subItemDefinitionWriter)
        {
            this.itemDefinitionWriter = itemDefinitionWriter;
            this.subItemDefinitionWriter = subItemDefinitionWriter;
        }

        public Result WriteItem(ICompiledItemWriterContext context, PackageItem packageItem)
        {
            context.Writer.WriteStartObject();

            {
                var result = this.WriteItemInfo(context, packageItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            {
                var result = this.WriteItemDefinition(context, packageItem.Item);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            if (packageItem.Item is INamedCompiledItem typedItem)
            {
                var result = this.WriteItemTypeInfo(context, typedItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            if (packageItem.Item is IAttributableCompiledItem attributableItem)
            {
                var result = this.WriteItemAttributes(context, attributableItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            {
                var result = this.WriteSubItems(context, packageItem.Item);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteSubItems(ICompiledItemWriterContext context, ICompiledItem item)
        {
            if (!(item is ISubItemOwner subItemsOwner))
            {
                context.Writer.WriteBoolean("hasSubItems", false);

                return Result.Success;
            }

            context.Writer.WriteBoolean("hasSubItems", true);

            context.Writer.WriteStartArray("subItems");

            foreach (var subItem in subItemsOwner.SubItems)
            {
                var result = this.WriteSubItem(context, subItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            context.Writer.WriteEndArray();

            return Result.Success;
        }

        private Result WriteSubItem(ICompiledItemWriterContext context, ICompiledSubItem subItem)
        {
            context.Writer.WriteStartObject();

            {
                var result = this.WriteSubItemInfo(context, subItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            {
                var result = this.WriteSubItemDefinition(context, subItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            if (subItem is INamedCompiledSubItem typedSubItem)
            {
                var result = this.WriteSubItemTypeInfo(context, typedSubItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            if (subItem is IAttributableCompiledSubItem attributableItem)
            {
                var result = this.WriteSubItemAttributes(context, attributableItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteItemDefinition(ICompiledItemWriterContext context, ICompiledItem item)
        {
            context.Writer.WritePropertyName("definition");

            var result = this.itemDefinitionWriter.Write(context, item);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return Result.Success;
        }

        private Result WriteSubItemDefinition(ICompiledItemWriterContext context, ICompiledSubItem subItem)
        {
            context.Writer.WritePropertyName("definition");

            var result = this.subItemDefinitionWriter.Write(context, subItem);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return Result.Success;
        }

        private Result WriteItemInfo(ICompiledItemWriterContext context, PackageItem packageItem)
        {
            context.Writer.WriteNumber("id", packageItem.ItemId.ToInt());

            context.Writer.WriteString("type", packageItem.ItemType.ToString());

            return Result.Success;
        }

        private Result WriteSubItemInfo(ICompiledItemWriterContext context, ICompiledSubItem subItem)
        {
            context.Writer.WriteNumber("id", subItem.SubItemId.ToInt());

            context.Writer.WriteString("type", subItem.SubItemType.ToString());

            return Result.Success;
        }

        private Result WriteItemTypeInfo(ICompiledItemWriterContext context, INamedCompiledItem namedItem)
        {
            context.Writer.WritePropertyName("typeName");

            context.CommonWriters.WriteQualifiedTypeName(namedItem.TypeName);

            return Result.Success;
        }

        private Result WriteSubItemTypeInfo(ICompiledItemWriterContext context, INamedCompiledSubItem subitem)
        {
            context.Writer.WritePropertyName("typeName");

            context.CommonWriters.WriteTypeNameIdentifier(subitem.SubItemName.SubItemTypeName.SubItemName);

            return Result.Success;
        }

        private Result WriteItemAttributes(ICompiledItemWriterContext context, IAttributableCompiledItem attributableItem)
        {
            context.Writer.WritePropertyName("attributes");

            context.CommonWriters.WriteCompiledAttributes(attributableItem.Attributes);

            return Result.Success;
        }

        private Result WriteSubItemAttributes(ICompiledItemWriterContext context, IAttributableCompiledSubItem attributableItem)
        {
            context.Writer.WritePropertyName("attributes");

            context.CommonWriters.WriteCompiledAttributes(attributableItem.Attributes);

            return Result.Success;
        }
    }
}
