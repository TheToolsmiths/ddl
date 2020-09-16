using System;
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
            this.CommonBuilders = new CommonTypeResolvers(serviceProvider, this);
        }

        private RootScopeTypeResolveContext(
            CommonTypeResolvers commonBuilders,
            ScopeTypeReferenceResolver typeReferenceResolver)
        {
            this.TypeReferenceResolver = typeReferenceResolver;
            this.CommonBuilders = commonBuilders.CreateForScope(this);
        }

        public CommonTypeResolvers CommonBuilders { get; }

        public ScopeTypeReferenceResolver TypeReferenceResolver { get; }

        ICommonTypeResolvers IRootEntryTypeResolveContext.CommonTypeResolvers => this.CommonBuilders;

        IScopeTypeReferenceResolver IRootEntryTypeResolveContext.TypeReferenceResolver => this.TypeReferenceResolver;

        public IRootScopeTypeResolveContext CreateScopeContext()
        {
            return new RootScopeTypeResolveContext(this.CommonBuilders, this.TypeReferenceResolver);
        }

        public IRootItemTypeResolveContext CreateItemContext()
        {
            return new RootItemTypeResolveContext(this.CommonBuilders, this.TypeReferenceResolver);
        }

        public static IRootScopeTypeResolveContext CreateRootContext(
            IServiceProvider serviceProvider,
            ScopeTypeReferenceResolver typeReferenceResolver)
        {
            return new RootScopeTypeResolveContext(serviceProvider, typeReferenceResolver);
        }
    }
}
