using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Parser.TypeResolver.Common;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    internal class RootItemTypeResolveContext : IRootItemTypeResolveContext
    {
        public RootItemTypeResolveContext(
            RootScopeTypeResolveContext parentScopeContext,
            CommonTypeResolvers commonTypeResolvers,
            ScopeTypeReferenceResolver typeReferenceResolver,
            ScopeTypeNameResolver typeNameResolver)
        {
            this.ParentScopeContext = parentScopeContext;
            this.CommonTypeResolvers = commonTypeResolvers;
            this.TypeReferenceResolver = typeReferenceResolver;
            this.TypeNameResolver = typeNameResolver;
        }

        public RootScopeTypeResolveContext ParentScopeContext { get; }

        public CommonTypeResolvers CommonTypeResolvers { get; }

        public ScopeTypeReferenceResolver TypeReferenceResolver { get; }

        public ScopeTypeNameResolver TypeNameResolver { get; }

        ICommonTypeResolvers IRootEntryTypeResolveContext.CommonTypeResolvers => this.CommonTypeResolvers;

        IScopeTypeReferenceResolver IRootEntryTypeResolveContext.TypeReferenceResolver => this.TypeReferenceResolver;

        IScopeTypeNameResolver IRootEntryTypeResolveContext.TypeNameResolver => this.TypeNameResolver;

        public IRootItemTypeResolveContext AddTypeNameInfoToContext(TypedItemName typeName)
        {
            if (!(typeName.ItemName is GenericTypeNameIdentifier genericIdentifier))
            {
                return this;
            }

            return this.AddGenericParameters(genericIdentifier.GenericParameters);
        }

        private IRootItemTypeResolveContext AddGenericParameters(
            IReadOnlyList<GenericTypeNameParameter> genericParameters)
        {
            var updatedTypeReferenceResolver = this.TypeReferenceResolver.AddGenericParameters(genericParameters);

            var scopeContext = this.ParentScopeContext.CreateWithTypeResolver(updatedTypeReferenceResolver);

            return new RootItemTypeResolveContext(
                scopeContext,
                scopeContext.CommonTypeResolvers,
                updatedTypeReferenceResolver,
                this.TypeNameResolver);
        }
    }
}
