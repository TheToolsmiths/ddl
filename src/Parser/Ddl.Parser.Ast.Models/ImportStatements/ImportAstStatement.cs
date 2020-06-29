using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ImportStatements
{
    public class ImportAstStatement : AstRootItem
    {
        public ImportAstStatement(ImportItem rootItem)
        {
            this.RootItem = rootItem;
        }

        public ImportItem RootItem { get; }

        public override ContentUnitItemType ItemType => ContentUnitItemType.ImportStatement;
    }
}
