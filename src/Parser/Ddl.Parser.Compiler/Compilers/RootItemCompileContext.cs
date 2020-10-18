using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Types.Items;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Compiler.Common;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.TypeResolvers;

namespace TheToolsmiths.Ddl.Parser.Compiler.Compilers
{
    internal class RootItemCompileContext : IRootItemCompileContext
    {
        public RootItemCompileContext(
            RootScopeCompileContext parentScopeContext,
            CommonCompilers commonCompilers,
            ScopeTypeUseResolver typeUseResolver,
            ScopeTypeNameResolver typeNameResolver)
        {
            this.ParentScopeContext = parentScopeContext;
            this.CommonCompilers = commonCompilers;
            this.TypeUseResolver = typeUseResolver;
            this.TypeNameResolver = typeNameResolver;
        }

        public RootScopeCompileContext ParentScopeContext { get; }

        public CommonCompilers CommonCompilers { get; }

        public ScopeTypeUseResolver TypeUseResolver { get; }

        public ScopeTypeNameResolver TypeNameResolver { get; }

        ICommonCompilers IRootEntryTypeResolveContext.CommonCompilers => this.CommonCompilers;

        IScopeTypeUseResolver IRootEntryTypeResolveContext.TypeUseResolver => this.TypeUseResolver;

        IScopeTypeNameResolver IRootEntryTypeResolveContext.TypeNameResolver => this.TypeNameResolver;

        public IRootItemCompileContext AddTypeNameInfoToContext(ItemTypeName typeName)
        {
            if (!(typeName.ItemName is GenericTypeNameIdentifier genericIdentifier))
            {
                return this;
            }

            return this.AddGenericParameters(genericIdentifier.GenericParameters);
        }

        private IRootItemCompileContext AddGenericParameters(
            IReadOnlyList<GenericTypeNameParameter> genericParameters)
        {
            var updatedTypeReferenceResolver = this.TypeUseResolver.AddGenericParameters(genericParameters);

            var scopeContext = this.ParentScopeContext.CreateWithTypeResolver(updatedTypeReferenceResolver);

            return new RootItemCompileContext(
                scopeContext,
                scopeContext.CommonCompilers,
                updatedTypeReferenceResolver,
                this.TypeNameResolver);
        }
    }
}
