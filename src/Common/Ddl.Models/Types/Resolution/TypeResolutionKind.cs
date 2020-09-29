namespace TheToolsmiths.Ddl.Models.Types.Resolution
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
