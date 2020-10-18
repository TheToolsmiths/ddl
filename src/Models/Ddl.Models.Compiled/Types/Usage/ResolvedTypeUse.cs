using TheToolsmiths.Ddl.Models.Compiled.Types.Resolution;
using TheToolsmiths.Ddl.Models.Types.Usage.Locality;
using TheToolsmiths.Ddl.Models.Types.Usage.Modifiers;
using TheToolsmiths.Ddl.Models.Types.Usage.Storage;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Usage
{
    public class ResolvedTypeUse
    {
        public ResolvedTypeUse(
            TypeResolution typeResolution,
            TypeUseStorage storage,
            TypeUseLocality locality,
            TypeUseModifiers modifiers)
        {
            this.TypeResolution = typeResolution;
            this.Storage = storage;
            this.Locality = locality;
            this.Modifiers = modifiers;
        }

        public TypeResolution TypeResolution { get; }

        public TypeUseStorage Storage { get; }

        public TypeUseLocality Locality { get; }

        public TypeUseModifiers Modifiers { get; }
    }
}
