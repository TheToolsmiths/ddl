using System.Diagnostics;
using Ddl.Common.Models;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits
{
    [DebuggerDisplay("{" + nameof(Info) + "}")]
    public class ContentUnit
    {
        public ContentUnit(
            ContentUnitInfo info,
            IFileRootScope fileRootScope)
        {
            this.Id = ContentUnitId.CreateNew();

            this.Info = info;
            this.FileRootScope = fileRootScope;
        }

        public ContentUnitId Id { get; }

        public ContentUnitInfo Info { get; }

        public IFileRootScope FileRootScope { get; }
    }
}
