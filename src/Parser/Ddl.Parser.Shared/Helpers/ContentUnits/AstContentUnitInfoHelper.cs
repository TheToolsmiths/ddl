using TheToolsmiths.Ddl.Models.Ast.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;

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
