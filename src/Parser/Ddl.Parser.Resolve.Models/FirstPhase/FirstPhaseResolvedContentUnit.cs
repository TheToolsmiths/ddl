using System.Collections.Generic;
using Ddl.Common.Models;
using Ddl.Parser.Resolve.Models.FirstPhase.Scopes;
using TheToolsmiths.Ddl.Parser.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace Ddl.Parser.Resolve.Models.FirstPhase
{
    public class FirstPhaseResolvedContentUnit
    {
        public FirstPhaseResolvedContentUnit(
            ContentUnitId id,
            NamespacePath namespacePath,
            FirstPhaseResolvedScope rootScope,
            IReadOnlyList<EntityTypeReference> indexedTypes)
        {
            this.Id = id;
            this.RootScope = rootScope;
            this.IndexedTypes = indexedTypes;
            this.NamespacePath = namespacePath;
        }

        public ContentUnitId Id { get; }

        public FirstPhaseResolvedScope RootScope { get; }

        public IReadOnlyList<EntityTypeReference> IndexedTypes { get; }

        public NamespacePath NamespacePath { get; }
    }
}
