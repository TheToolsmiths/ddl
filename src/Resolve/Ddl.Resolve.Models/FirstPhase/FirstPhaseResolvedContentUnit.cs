using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase.Scopes;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace Ddl.Resolve.Models.FirstPhase
{
    public class FirstPhaseResolvedContentUnit
    {
        public FirstPhaseResolvedContentUnit(ContentUnitId id, FirstPhaseNamespacePath namespacePath, FirstPhaseResolvedScope rootScope)
        {
            this.Id = id;
            this.RootScope = rootScope;
            this.NamespacePath = namespacePath;
        }

        public ContentUnitId Id { get; }

        public FirstPhaseResolvedScope RootScope { get; }

        public FirstPhaseNamespacePath NamespacePath { get; }
    }
}
