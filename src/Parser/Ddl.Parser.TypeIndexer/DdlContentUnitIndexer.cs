using System;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.TypeIndexer.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Namespaces;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class DdlContentUnitIndexer
    {
        private readonly NamespacePathResolver namespacePathResolver;
        private readonly TypeReferenceIndexer typeReferenceIndexer;

        public DdlContentUnitIndexer(NamespacePathResolver namespacePathResolver, TypeReferenceIndexer typeReferenceIndexer)
        {
            this.namespacePathResolver = namespacePathResolver;
            this.typeReferenceIndexer = typeReferenceIndexer;
        }

        public Result<ContentUnitIndexedTypes> Index(ContentUnit contentUnit)
        {
            RootNamespacePath namespacePath;
            {
                var result = this.namespacePathResolver.ResolveContentUnitNamespace(contentUnit.Info);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                namespacePath = result.Value;
            }

            {
                var context = new TypeIndexingContext(namespacePath);

                var rootScope = contentUnit.RootScope;

                var result = this.typeReferenceIndexer.IndexScopeTypes(context, rootScope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var indexedTypes = ContentUnitIndexedTypesBuilder.BuildFromList(contentUnit.Id, namespacePath, context.IndexedTypes);

                return Result.FromValue(indexedTypes);
            }
        }
    }
}
