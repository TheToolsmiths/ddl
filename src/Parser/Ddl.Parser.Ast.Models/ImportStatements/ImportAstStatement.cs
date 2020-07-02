using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ImportStatements
{
    public class ImportAstStatement : AstRootItem
    {
        public ImportAstStatement(ImportItem rootItem)
        {
            this.RootItem = rootItem;
        }

        public ImportItem RootItem { get; }

        public override AstItemType ItemType => CommonItemTypes.ImportStatement;
    }
}
