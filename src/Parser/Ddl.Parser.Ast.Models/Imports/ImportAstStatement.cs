using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Imports
{
    public class ImportAstStatement : AstRootItem, IRootItem
    {
        public ImportAstStatement(ImportItem rootItem)
        {
            this.RootItem = rootItem;
        }

        public ImportItem RootItem { get; }

        public override ContentUnitItemType ItemType => ContentUnitItemType.ImportStatement;
    }
}
