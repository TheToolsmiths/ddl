namespace TheToolsmiths.Ddl.Models.Compiled.Types.Resolution
{
    public enum TypeResolutionKind
    {
        Unresolved,
        MatchImport,
        MatchGenericParameter,
        ResolvedType,
        Builtin,
        Namespace
    }
}
