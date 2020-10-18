using System;

using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;
using TheToolsmiths.Ddl.Parser.Compiler.Compilers;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.TypeResolvers;
using TheToolsmiths.Ddl.Parser.Compiler.TypeResolvers.BuiltinTypes;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler
{
    public class DdlContentUnitCompiler
    {
        private readonly IContentUnitCompiler compiler;
        private readonly IServiceProvider serviceProvider;

        public DdlContentUnitCompiler(IServiceProvider serviceProvider, IContentUnitCompiler compiler)
        {
            this.serviceProvider = serviceProvider;
            this.compiler = compiler;
        }

        public Result<CompiledContentUnit> Compile(
            ContentUnit contentUnit,
            ContentUnitsTypeIndex packageTypeIndex)
        {
            IRootScopeCompileContext scopeContext = this.CreateScopeContext(contentUnit, packageTypeIndex);

            var result = this.compiler.ResolveContentUnitScopeTypes(scopeContext, contentUnit.RootScope);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var resolvedContentUnit = new CompiledContentUnit(contentUnit.Id, contentUnit.Info, result.Value);

            return Result.FromValue(resolvedContentUnit);
        }

        private IRootScopeCompileContext CreateScopeContext(ContentUnit contentUnit, ContentUnitsTypeIndex packageTypeIndex)
        {
            if (packageTypeIndex.TryGetContentUnitNamespace(contentUnit.Id, out var rootNamespace) == false)
            {
                throw new NotImplementedException();
            }

            var builtinReferences = new BuiltinTypeReferenceResolverBuilder();

            var builtinTypeReferenceResolver = builtinReferences.Build();

            var typeReferenceResolver = ScopeTypeUseResolver.CreateForNamespace(
                packageTypeIndex,
                rootNamespace,
                builtinTypeReferenceResolver);

            var qualifiedNamespacePath = QualifiedNamespacePath.CreateFromIdentifiers(rootNamespace.NamespacePath.Identifiers);

            var typeNameResolver = new ScopeTypeNameResolver(qualifiedNamespacePath);

            var scopeContext = RootScopeCompileContext.CreateRootContext(
                this.serviceProvider,
                typeReferenceResolver,
                typeNameResolver);

            return scopeContext;
        }
    }
}
