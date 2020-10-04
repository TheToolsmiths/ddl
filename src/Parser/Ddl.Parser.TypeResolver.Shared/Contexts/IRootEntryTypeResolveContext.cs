namespace TheToolsmiths.Ddl.Parser.TypeResolver.Contexts
{
    public interface IRootEntryTypeResolveContext
    {
        ICommonTypeResolvers CommonTypeResolvers { get; }

        IScopeTypeReferenceResolver TypeReferenceResolver { get; }
        
        IScopeTypeNameResolver TypeNameResolver { get; }
    }
}
