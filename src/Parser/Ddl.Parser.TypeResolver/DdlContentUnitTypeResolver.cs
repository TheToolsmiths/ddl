using System;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences;
using TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public class DdlContentUnitTypeResolver
    {
        private readonly IContentUnitTypeResolver typeResolver;
        private readonly IServiceProvider serviceProvider;

        public DdlContentUnitTypeResolver(IServiceProvider serviceProvider, IContentUnitTypeResolver typeResolver)
        {
            this.serviceProvider = serviceProvider;
            this.typeResolver = typeResolver;
        }

        public Result<ContentUnit> ResolveTypes(ContentUnit contentUnit, TypeReferenceIndex typeIndex)
        {
            var rootNamespace = typeIndex.GetContentUnitNamespaceIndex(contentUnit.Id);

            var typeReferenceResolver = ScopeTypeReferenceResolver.CreateForNamespace(typeIndex, rootNamespace);

            var scopeContext = RootScopeTypeResolveContext.CreateRootContext(this.serviceProvider, typeReferenceResolver);

            var result = this.typeResolver.ResolveContentUnitScopeTypes(scopeContext, contentUnit.RootScope);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var resolvedContentUnit = new ContentUnit(contentUnit.Id, contentUnit.Info, result.Value);

            return Result.FromValue(resolvedContentUnit);
        }
    }
}
