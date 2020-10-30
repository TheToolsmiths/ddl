using TheToolsmiths.Ddl.Models.Ast.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Parser.Helpers.ContentUnits
{
    public static class AstContentUnitInfoHelper
    {
        public static ContentUnitInfo ToContentUnitInfo(AstContentUnitInfo info)
        {
            string id = info.Id;
            string name = info.Name;
            string relativePath = info.RelativePath;
            var file = info.File;

            return new ContentUnitInfo(id, name, relativePath, file);
        }
    }
}
