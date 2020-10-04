using System;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Packages.Index;
using TheToolsmiths.Ddl.Parser.TypeIndexer.TypeResolvers.BuiltinTypes;
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

        public Result<ContentUnit> ResolveTypes(
            ContentUnit contentUnit,
            PackageTypeIndex packageTypeIndex)
        {
            if (packageTypeIndex.TryGetContentUnitNamespace(contentUnit.Id, out var rootNamespace) == false)
            {
                throw new NotImplementedException();
            }

            var builtinReferences = new BuiltinTypeReferenceIndexBuilder();

            var builtinTypeReferenceResolver = builtinReferences.Build();

            var typeReferenceResolver = ScopeTypeReferenceResolver.CreateForNamespace(packageTypeIndex, rootNamespace, builtinTypeReferenceResolver);

            var typeNameResolver = new ScopeTypeNameResolver(rootNamespace.NamespacePath);

            var scopeContext = RootScopeTypeResolveContext.CreateRootContext(this.serviceProvider, typeReferenceResolver, typeNameResolver);

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
