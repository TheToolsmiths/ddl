using TheToolsmiths.Ddl.Models.Build.Types.Paths;
using TheToolsmiths.Ddl.Models.Types.Usage.Locality;
using TheToolsmiths.Ddl.Models.Types.Usage.Modifiers;
using TheToolsmiths.Ddl.Models.Types.Usage.Storage;

namespace TheToolsmiths.Ddl.Models.Build.Types.Usage
{
    public class TypeUse
    {
        public TypeUse(
            TypePath typePath,
            TypeUseStorage storage,
            TypeUseLocality locality,
            TypeUseModifiers modifiers)
        {
            this.TypePath = typePath;
            this.Storage = storage;
            this.Locality = locality;
            this.Modifiers = modifiers;
        }

        public TypePath TypePath { get; }

        public TypeUseStorage Storage { get; }

        public TypeUseLocality Locality { get; }

        public TypeUseModifiers Modifiers { get; }
    }
}
