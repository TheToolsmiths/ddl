using System;
using TheToolsmiths.Ddl.Models.Build.ImportPaths;
using TheToolsmiths.Ddl.Parser.Compiler.Common;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.TypeResolvers;

namespace TheToolsmiths.Ddl.Parser.Compiler.Compilers
{
    public class RootScopeCompileContext : IRootScopeCompileContext
    {
        private RootScopeCompileContext(
            IServiceProvider serviceProvider,
            ScopeTypeUseResolver typeUseResolver,
            ScopeTypeNameResolver typeNameResolver)
        {
            this.TypeUseResolver = typeUseResolver;
            this.TypeNameResolver = typeNameResolver;
            this.CommonCompilers = new CommonCompilers(serviceProvider, this);
        }

        private RootScopeCompileContext(
            CommonCompilers commonBuilders,
            ScopeTypeUseResolver typeUseResolver,
            ScopeTypeNameResolver typeNameResolver)
        {
            this.TypeUseResolver = typeUseResolver;
            this.TypeNameResolver = typeNameResolver;
            this.CommonCompilers = commonBuilders.CreateForScope(this);
        }

        public CommonCompilers CommonCompilers { get; }

        public ScopeTypeUseResolver TypeUseResolver { get; }

        public ScopeTypeNameResolver TypeNameResolver { get; }

        ICommonCompilers IRootEntryTypeResolveContext.CommonCompilers => this.CommonCompilers;

        IScopeTypeUseResolver IRootEntryTypeResolveContext.TypeUseResolver => this.TypeUseResolver;

        IScopeTypeNameResolver IRootEntryTypeResolveContext.TypeNameResolver => this.TypeNameResolver;

        public IRootScopeCompileContext CreateScopeContext()
        {
            return new RootScopeCompileContext(this.CommonCompilers, this.TypeUseResolver, this.TypeNameResolver);
        }

        public IRootItemCompileContext CreateItemContext()
        {
            return new RootItemCompileContext(
                this,
                this.CommonCompilers,
                this.TypeUseResolver,
                this.TypeNameResolver);
        }

        public IRootScopeCompileContext AddImportPaths(
            IRootScopeCompileContext context,
            ImportStatementCollection imports)
        {
            if (imports.Items.Count == 0)
            {
                return context;
            }

            var updatedTypeReferenceResolver = this.TypeUseResolver.AddImports(imports);

            return new RootScopeCompileContext(this.CommonCompilers, updatedTypeReferenceResolver, this.TypeNameResolver);
        }

        public static IRootScopeCompileContext CreateRootContext(
            IServiceProvider serviceProvider,
            ScopeTypeUseResolver typeUseResolver,
            ScopeTypeNameResolver typeNameResolver)
        {
            return new RootScopeCompileContext(serviceProvider, typeUseResolver, typeNameResolver);
        }

        public RootScopeCompileContext CreateWithTypeResolver(ScopeTypeUseResolver scopeTypeUseResolver)
        {
            return new RootScopeCompileContext(this.CommonCompilers, scopeTypeUseResolver, this.TypeNameResolver);
        }
    }
}
