namespace TheToolsmiths.Ddl.Models.Build.Types.Resolution
{
    public abstract class TypeResolution
    {
        protected TypeResolution(TypeResolutionKind resolutionKind)
        {
            this.ResolutionKind = resolutionKind;
        }

        public static TypeResolution Unresolved { get; } = new UnresolvedType();

        public TypeResolutionKind ResolutionKind { get; }
    }
}
