using System;
using System.Collections.Generic;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase;
using Ddl.Resolve.Models.FirstPhase.Indexing;
using Ddl.Resolve.Models.FirstPhase.Scopes;
using Ddl.Resolve.Models.FirstPhase.TypePaths;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Resolve.FirstPhase.Namespaces;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class FirstPhaseContentUnitResolver
    {
        private readonly NamespacePathResolver namespacePathResolver;
        private readonly ScopeContentResolver rootScopeResolver;
        private readonly TypeReferenceIndexer typeReferenceIndexer;

        public FirstPhaseContentUnitResolver(
            NamespacePathResolver namespacePathResolver,
            ScopeContentResolver rootScopeResolver,
            TypeReferenceIndexer typeReferenceIndexer)
        {
            this.namespacePathResolver = namespacePathResolver;
            this.rootScopeResolver = rootScopeResolver;
            this.typeReferenceIndexer = typeReferenceIndexer;
        }

        public Result<FirstPhaseResolvedContentUnit> ResolveContentUnit(ContentUnit contentUnit)
        {
            FirstPhaseNamespacePath namespacePath;
            {
                var result = this.namespacePathResolver.ResolveContentUnitNamespace(contentUnit.Info);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                namespacePath = result.Value;
            }

            FirstPhaseResolvedScope rootScope;
            {
                var scopeContext = ContentUnitScopeResolveContext.CreateRootContext(namespacePath);

                var result = this.rootScopeResolver
                    .ResolveScopeContent(scopeContext, contentUnit.FileRootScope.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                rootScope = result.Value;
            }

            IReadOnlyList<IndexedTypeReference> indexedTypes;
            {
                var result = this.typeReferenceIndexer.IndexResolvedScopeTypes(contentUnit.Id, namespacePath, rootScope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                indexedTypes = result.Value;
            }

            var resolvedContentUnit = new FirstPhaseResolvedContentUnit(contentUnit.Id, namespacePath, rootScope, indexedTypes);

            return Result.FromValue(resolvedContentUnit);
        }
    }
}
