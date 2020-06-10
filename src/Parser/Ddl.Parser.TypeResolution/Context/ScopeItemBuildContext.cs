using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.TypeResolution.Context
{
    public class ScopeItemBuildContext : IScopeItemBuildContext
    {
        private readonly NamespacePath scopeNamespace;
        private readonly IServiceProvider serviceProvider;
        private readonly ScopeTypeResolver typeResolver;

        private ScopeItemBuildContext(
            NamespacePath scopeNamespace,
            ScopeTypeResolver typeResolver,
            IServiceProvider serviceProvider)
        {
            this.typeResolver = typeResolver;
            this.scopeNamespace = scopeNamespace;
            this.serviceProvider = serviceProvider;
        }

        public IScopeTypeResolver TypeResolver => this.typeResolver;

        public static ScopeItemBuildContext CreateForRoot(
            NamespacePath scopeNamespace,
            IReadOnlyList<EntityTypeReference> indexedTypes,
            IServiceProvider serviceProvider)
        {
            var typeResolver = ScopeTypeResolver.CreateFromIndexedTypes(scopeNamespace, indexedTypes);

            return new ScopeItemBuildContext(scopeNamespace, typeResolver, serviceProvider);
        }

        //public ScopeItemBuildContext CreateChildScope(IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
        //{
        //    var typeResolver = this.typeResolver.CreateScopeWithImportPathLayer(this.scopeNamespace, importPaths);

        //    return new ScopeItemBuildContext(this.scopeNamespace, typeResolver, this.serviceProvider);
        //}
    }
}
