namespace TheToolsmiths.Ddl.Parser.Models.Types
{
    public abstract class ResolvedType
    {
        public abstract ResolvedTypePartKind ResolvedKind { get; }
    }

    public enum ResolvedTypeKind
    {
        Resolved,
        Incomplete,
        Unresolved
    }
}
