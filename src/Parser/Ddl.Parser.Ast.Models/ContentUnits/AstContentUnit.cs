using System.Diagnostics;
using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits
{
    [DebuggerDisplay("{" + nameof(Info) + "}")]
    public class AstContentUnit
    {
        public AstContentUnit(
            ContentUnitInfo info,
            IAstFileRootScope fileRootScope)
        {
            this.Id = ContentUnitId.CreateNew();

            this.Info = info;
            this.FileRootScope = fileRootScope;
        }

        public ContentUnitId Id { get; }

        public ContentUnitInfo Info { get; }

        public IAstFileRootScope FileRootScope { get; }
    }
}
