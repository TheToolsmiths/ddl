using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Ast.ImportStatements
{
    public class ImportAstStatement : AstRootItem
    {
        public ImportAstStatement(ImportRoot rootItem)
        {
            this.RootItem = rootItem;
        }

        public ImportRoot RootItem { get; }

        public override AstItemType ItemType => CommonItemTypes.ImportStatement;
    }
}
