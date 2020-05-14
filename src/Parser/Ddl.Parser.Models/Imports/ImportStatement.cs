using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Models.Imports
{
    public class ImportStatement : RootItem
    {
        public ImportStatement(ImportItem rootItem)
        {
            this.RootItem = rootItem;
        }

        public ImportItem RootItem { get; }

        public override ContentUnitItemType ItemType => ContentUnitItemType.ImportStatement;
    }
}
