using TheToolsmiths.Ddl.Parser.TypeResolver.Common;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    internal class RootItemTypeResolveContext : IRootItemTypeResolveContext
    {
        public RootItemTypeResolveContext(
            CommonTypeResolvers commonTypeResolvers,
            IScopeTypeReferenceResolver typeReferenceResolver)
        {
            this.CommonTypeResolvers = commonTypeResolvers;
            this.TypeReferenceResolver = typeReferenceResolver;
        }

        public ICommonTypeResolvers CommonTypeResolvers { get; }

        public IScopeTypeReferenceResolver TypeReferenceResolver { get; }
    }
}
