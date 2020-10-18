using TheToolsmiths.Ddl.Models.Compiled.Types.Resolution;
using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Resolve
{
    public class ReferencedTypeResolveState
    {
        public ReferencedTypeResolveState(ResolvedTypeUse typeReference, TypeResolution typeResolution)
        {
            this.TypeReference = typeReference;
            this.TypeResolution = typeResolution;
        }

        public ResolvedTypeUse TypeReference { get; }

        public TypeResolution TypeResolution { get; }
    }
}
