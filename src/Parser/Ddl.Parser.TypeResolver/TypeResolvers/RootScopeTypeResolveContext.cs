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
            ScopeTypeReferenceResolver typeReferenceResolver)
        {
            this.TypeReferenceResolver = typeReferenceResolver;
            this.CommonTypeResolvers = new CommonTypeResolvers(serviceProvider, this);
        }

        private RootScopeTypeResolveContext(
            CommonTypeResolvers commonBuilders,
            ScopeTypeReferenceResolver typeReferenceResolver)
        {
            this.TypeReferenceResolver = typeReferenceResolver;
            this.CommonTypeResolvers = commonBuilders.CreateForScope(this);
        }

        public CommonTypeResolvers CommonTypeResolvers { get; }

        public ScopeTypeReferenceResolver TypeReferenceResolver { get; }

        ICommonTypeResolvers IRootEntryTypeResolveContext.CommonTypeResolvers => this.CommonTypeResolvers;

        IScopeTypeReferenceResolver IRootEntryTypeResolveContext.TypeReferenceResolver => this.TypeReferenceResolver;

        public IRootScopeTypeResolveContext CreateScopeContext()
        {
            return new RootScopeTypeResolveContext(this.CommonTypeResolvers, this.TypeReferenceResolver);
        }

        public IRootItemTypeResolveContext CreateItemContext()
        {
            return new RootItemTypeResolveContext(this, this.CommonTypeResolvers, this.TypeReferenceResolver);
        }

        public static IRootScopeTypeResolveContext CreateRootContext(
            IServiceProvider serviceProvider,
            ScopeTypeReferenceResolver typeReferenceResolver)
        {
            return new RootScopeTypeResolveContext(serviceProvider, typeReferenceResolver);
        }

        public RootScopeTypeResolveContext CreateWithTypeResolver(ScopeTypeReferenceResolver scopeTypeReferenceResolver)
        {
            return new RootScopeTypeResolveContext(this.CommonTypeResolvers, scopeTypeReferenceResolver);
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

            return new RootScopeTypeResolveContext(this.CommonTypeResolvers, updatedTypeReferenceResolver);
        }
    }
}
