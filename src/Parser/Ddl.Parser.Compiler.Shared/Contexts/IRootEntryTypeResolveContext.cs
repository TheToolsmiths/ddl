namespace TheToolsmiths.Ddl.Parser.Compiler.Contexts
{
    public interface IRootEntryTypeResolveContext
    {
        ICommonCompilers CommonCompilers { get; }

        IScopeTypeUseResolver TypeUseResolver { get; }
        
        IScopeTypeNameResolver TypeNameResolver { get; }
    }
}
