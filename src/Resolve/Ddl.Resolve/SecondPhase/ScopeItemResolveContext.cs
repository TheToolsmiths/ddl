using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase.ImportPaths;
using Ddl.Resolve.Models.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Namespaces;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    public class ScopeItemResolveContext
    {
        private readonly NamespacePath scopeNamespace;

        private ScopeItemResolveContext(NamespacePath scopeNamespace, ScopeTypeResolver typeResolver)
        {
            this.TypeResolver = typeResolver;
            this.scopeNamespace = scopeNamespace;
        }

        public ScopeTypeResolver TypeResolver { get; }

        public static ScopeItemResolveContext CreateForRoot(
            NamespacePath scopeNamespace,
            IReadOnlyList<TypePathEntityReference> indexedTypes)
        {
            var typeResolver = ScopeTypeResolver.CreateFromIndexedTypes(scopeNamespace, indexedTypes);

            return new ScopeItemResolveContext(scopeNamespace, typeResolver);
        }

        public ScopeItemResolveContext CreateChildScope(IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
        {
            var typeResolver = this.TypeResolver.CreateScopeWithImportPathLayer(this.scopeNamespace, importPaths);

            return new ScopeItemResolveContext(this.scopeNamespace, typeResolver);
        }
    }
}
