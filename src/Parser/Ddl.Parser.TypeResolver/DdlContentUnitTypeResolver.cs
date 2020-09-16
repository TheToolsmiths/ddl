using System;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;
using TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public class DdlContentUnitTypeResolver
    {
        private readonly IRootScopeTypeResolver scopeTypeResolver;
        private readonly IServiceProvider serviceProvider;

        public DdlContentUnitTypeResolver(IServiceProvider serviceProvider, IRootScopeTypeResolver scopeTypeResolver)
        {
            this.serviceProvider = serviceProvider;
            this.scopeTypeResolver = scopeTypeResolver;
        }

        public Result<ContentUnit> ResolveTypes(ContentUnit contentUnit, TypeReferenceIndex typeIndex)
        {
            var rootNamespace = typeIndex.GetContentUnitNamespaceIndex(contentUnit.Id);

            var typeReferenceResolver = ScopeTypeReferenceResolver.CreateForNamespace(typeIndex, rootNamespace);

            var scopeContext = RootScopeTypeResolveContext.CreateRootContext(this.serviceProvider, typeReferenceResolver);

            var result = this.scopeTypeResolver.ResolveScopeTypes(scopeContext, contentUnit.RootScope);

            switch (result)
            {
                case RootScopeTypeResolveError error:
                    throw new NotImplementedException();

                case RootScopeTypeResolveSuccess success:
                    var resolvedContentUnit = new ContentUnit(contentUnit.Id, contentUnit.Info, success.ResolvedScope);
                    return Result.FromValue(resolvedContentUnit);

                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }
        }
    }
}
