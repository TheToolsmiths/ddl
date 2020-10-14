using TheToolsmiths.Ddl.Models.Build.Types.Resolution;

namespace TheToolsmiths.Ddl.Models.Build.Types.References.Resolve
{
    public class ReferencedTypeResolveState
    {
        public ReferencedTypeResolveState(TypeReference typeReference, TypeResolution typeResolution)
        {
            this.TypeReference = typeReference;
            this.TypeResolution = typeResolution;
        }

        public TypeReference TypeReference { get; }

        public TypeResolution TypeResolution { get; }
    }
}
