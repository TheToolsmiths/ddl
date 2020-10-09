using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Parser.Packager.Items
{
    public class PackageTypedItem : PackageItem
    {
        public PackageTypedItem(
            in ItemId itemId,
            ItemType itemType,
            TypedItemName typeName,
            QualifiedItemTypeNameResolution typeNameResolution,
            ITypedRootItem typedItem)
            : base(in itemId, itemType, typedItem)
        {
            this.TypeName = typeName;
            this.TypeNameResolution = typeNameResolution;
            this.TypedItem = typedItem;
        }

        public TypedItemName TypeName { get; }

        public QualifiedItemTypeNameResolution TypeNameResolution { get; }

        public ITypedRootItem TypedItem { get; }
    }
}
