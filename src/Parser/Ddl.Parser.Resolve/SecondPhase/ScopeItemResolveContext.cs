using System;
using System.Collections.Generic;
using Ddl.Parser.Resolve.Models.FirstPhase.ImportPaths;
using TheToolsmiths.Ddl.Parser.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Resolve.SecondPhase.Common.Resolvers;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    public class ScopeItemResolveContext
    {
        private readonly NamespacePath scopeNamespace;
        private readonly IServiceProvider serviceProvider;

        private ScopeItemResolveContext(
            NamespacePath scopeNamespace,
            ScopeTypeResolver typeResolver,
            IServiceProvider serviceProvider)
        {
            this.TypeResolver = typeResolver;
            this.scopeNamespace = scopeNamespace;
            this.serviceProvider = serviceProvider;
            this.CommonResolvers = new CommonResolvers(this, serviceProvider);
        }

        public ICommonResolvers CommonResolvers { get; }

        public ScopeTypeResolver TypeResolver { get; }

        public static ScopeItemResolveContext CreateForRoot(
            NamespacePath scopeNamespace,
            IReadOnlyList<EntityTypeReference> indexedTypes,
            IServiceProvider serviceProvider)
        {
            var typeResolver = ScopeTypeResolver.CreateFromIndexedTypes(scopeNamespace, indexedTypes);

            return new ScopeItemResolveContext(scopeNamespace, typeResolver, serviceProvider);
        }

        public ScopeItemResolveContext CreateChildScope(IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
        {
            var typeResolver = this.TypeResolver.CreateScopeWithImportPathLayer(this.scopeNamespace, importPaths);

            return new ScopeItemResolveContext(this.scopeNamespace, typeResolver, this.serviceProvider);
        }
    }
}
