using System;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Namespaces;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class DdlContentUnitIndexer
    {
        private readonly IServiceProvider serviceProvider;
        private readonly NamespacePathResolver namespacePathResolver;
        private readonly TypeReferenceIndexer typeReferenceIndexer;

        public DdlContentUnitIndexer(IServiceProvider serviceProvider, NamespacePathResolver namespacePathResolver, TypeReferenceIndexer typeReferenceIndexer)
        {
            this.serviceProvider = serviceProvider;
            this.namespacePathResolver = namespacePathResolver;
            this.typeReferenceIndexer = typeReferenceIndexer;
        }

        public Result<ContentUnitIndexedTypes> Index(ContentUnit contentUnit)
        {
            NamespacePath namespacePath;
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

                var indexedTypes = this.BuildContentUnitIndexedTypes(context, contentUnit);

                return Result.FromValue(indexedTypes);
            }
        }

        private ContentUnitIndexedTypes BuildContentUnitIndexedTypes(TypeIndexingContext context, ContentUnit contentUnit)
        {
            var builder = new ContentUnitIndexedTypesBuilder(contentUnit.Id);

            foreach (var typeReference in context.IndexedTypes)
            {
                builder.AddType(typeReference);
            }

            return builder.Build();
        }
    }
}
