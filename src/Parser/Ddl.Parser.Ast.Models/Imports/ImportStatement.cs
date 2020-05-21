using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Imports
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
