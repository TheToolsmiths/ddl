using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Parser.Build.Models.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build.Models.ContentUnits
{
    public class FirstPhaseResolvedContentUnit
    {
        public FirstPhaseResolvedContentUnit(
            ContentUnitId id,
            FirstPhaseResolvedScope rootScope)
        {
            this.Id = id;
            this.RootScope = rootScope;
        }

        public ContentUnitId Id { get; }

        public FirstPhaseResolvedScope RootScope { get; }
    }
}
