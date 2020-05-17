using System.Collections.Generic;
using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase.Scopes;
using Ddl.Resolve.Models.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Namespaces;

namespace Ddl.Resolve.Models.FirstPhase
{
    public class FirstPhaseResolvedContentUnit
    {
        public FirstPhaseResolvedContentUnit(
            ContentUnitId id,
            NamespacePath namespacePath,
            FirstPhaseResolvedScope rootScope,
            IReadOnlyList<TypePathEntityReference> indexedTypes)
        {
            this.Id = id;
            this.RootScope = rootScope;
            this.IndexedTypes = indexedTypes;
            this.NamespacePath = namespacePath;
        }

        public ContentUnitId Id { get; }

        public FirstPhaseResolvedScope RootScope { get; }

        public IReadOnlyList<TypePathEntityReference> IndexedTypes { get; }

        public NamespacePath NamespacePath { get; }
    }
}
