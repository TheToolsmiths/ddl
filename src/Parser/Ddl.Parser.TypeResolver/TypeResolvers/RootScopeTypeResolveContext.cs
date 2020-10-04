using System;

using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Parser.TypeResolver.Common;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    public class RootScopeTypeResolveContext : IRootScopeTypeResolveContext
    {
        private RootScopeTypeResolveContext(
            IServiceProvider serviceProvider,
            ScopeTypeReferenceResolver typeReferenceResolver,
            ScopeTypeNameResolver typeNameResolver)
        {
            this.TypeReferenceResolver = typeReferenceResolver;
            this.TypeNameResolver = typeNameResolver;
            this.CommonTypeResolvers = new CommonTypeResolvers(serviceProvider, this);
        }

        private RootScopeTypeResolveContext(
            CommonTypeResolvers commonBuilders,
            ScopeTypeReferenceResolver typeReferenceResolver,
            ScopeTypeNameResolver typeNameResolver)
        {
            this.TypeReferenceResolver = typeReferenceResolver;
            this.TypeNameResolver = typeNameResolver;
            this.CommonTypeResolvers = commonBuilders.CreateForScope(this);
        }

        public CommonTypeResolvers CommonTypeResolvers { get; }

        public ScopeTypeReferenceResolver TypeReferenceResolver { get; }

        public ScopeTypeNameResolver TypeNameResolver { get; }

        ICommonTypeResolvers IRootEntryTypeResolveContext.CommonTypeResolvers => this.CommonTypeResolvers;

        IScopeTypeReferenceResolver IRootEntryTypeResolveContext.TypeReferenceResolver => this.TypeReferenceResolver;

        IScopeTypeNameResolver IRootEntryTypeResolveContext.TypeNameResolver => this.TypeNameResolver;

        public IRootScopeTypeResolveContext CreateScopeContext()
        {
            return new RootScopeTypeResolveContext(this.CommonTypeResolvers, this.TypeReferenceResolver, this.TypeNameResolver);
        }

        public IRootItemTypeResolveContext CreateItemContext()
        {
            return new RootItemTypeResolveContext(
                this,
                this.CommonTypeResolvers,
                this.TypeReferenceResolver,
                this.TypeNameResolver);
        }

        public IRootScopeTypeResolveContext AddImportPaths(
            IRootScopeTypeResolveContext context,
            ImportStatementCollection imports)
        {
            if (imports.Items.Count == 0)
            {
                return context;
            }

            var updatedTypeReferenceResolver = this.TypeReferenceResolver.AddImports(imports);

            return new RootScopeTypeResolveContext(this.CommonTypeResolvers, updatedTypeReferenceResolver, this.TypeNameResolver);
        }

        public static IRootScopeTypeResolveContext CreateRootContext(
            IServiceProvider serviceProvider,
            ScopeTypeReferenceResolver typeReferenceResolver,
            ScopeTypeNameResolver typeNameResolver)
        {
            return new RootScopeTypeResolveContext(serviceProvider, typeReferenceResolver, typeNameResolver);
        }

        public RootScopeTypeResolveContext CreateWithTypeResolver(ScopeTypeReferenceResolver scopeTypeReferenceResolver)
        {
            return new RootScopeTypeResolveContext(this.CommonTypeResolvers, scopeTypeReferenceResolver, this.TypeNameResolver);
        }
    }
}
