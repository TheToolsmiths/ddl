using System.Diagnostics;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits
{
    [DebuggerDisplay("{" + nameof(Info) + "}")]
    public class AstContentUnit
    {
        public AstContentUnit(
            AstContentUnitInfo info,
            AstContentUnitScope fileRootScope)
        {
            this.Info = info;
            this.FileRootScope = fileRootScope;
        }

        public AstContentUnitInfo Info { get; }

        public AstContentUnitScope FileRootScope { get; }
    }
}
