using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ImportStatements
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
