using System.Collections.Generic;
using Ddl.Parser.Resolve.Models.Common.TypeReferences;
using Ddl.Parser.Resolve.Models.FirstPhase.ImportPaths;
using TheToolsmiths.Ddl.Parser.Models.TypePaths.Namespaces;

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
