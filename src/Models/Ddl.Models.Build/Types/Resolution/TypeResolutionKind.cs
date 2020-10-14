namespace TheToolsmiths.Ddl.Models.Build.Types.Resolution
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
