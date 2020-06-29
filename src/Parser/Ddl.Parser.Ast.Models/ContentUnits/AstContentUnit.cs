using System.Diagnostics;
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
            this.Info = info;
            this.FileRootScope = fileRootScope;
        }

        public ContentUnitInfo Info { get; }

        public IAstFileRootScope FileRootScope { get; }
    }
}
