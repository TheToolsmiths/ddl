namespace TheToolsmiths.Ddl.Models.Compiled.Types.References.Resolve
{
    public class ResolveStateHandle
    {
        public ResolveStateHandle(int typeIndex, ResolveState state, ResolvedTypeKind resolvedKind)
        {
            this.TypeIndex = typeIndex;
            this.State = state;
            this.ResolvedKind = resolvedKind;
        }

        public int TypeIndex { get; }

        public ResolveState State { get; }

        public ResolvedTypeKind ResolvedKind { get; }
    }
}
