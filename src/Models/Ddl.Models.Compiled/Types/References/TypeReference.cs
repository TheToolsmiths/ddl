using TheToolsmiths.Ddl.Models.Compiled.Types.References.Locality;
using TheToolsmiths.Ddl.Models.Compiled.Types.References.Modifiers;
using TheToolsmiths.Ddl.Models.Compiled.Types.References.Resolve;
using TheToolsmiths.Ddl.Models.Compiled.Types.References.Storage;
using TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.References
{
    public class TypeReference
    {
        public TypeReference(
            TypeReferencePath typePath,
            TypeStorage storage,
            TypeLocalityInformation locality,
            TypeModifiers modifiers,
            ResolveStateHandle typeResolve)
        {
            this.TypePath = typePath;
            this.Storage = storage;
            this.Locality = locality;
            this.Modifiers = modifiers;
            this.TypeResolve = typeResolve;
        }

        public TypeReferencePath TypePath { get; }

        public TypeStorage Storage { get; }

        public TypeLocalityInformation Locality { get; }

        public TypeModifiers Modifiers { get; }

        public ResolveStateHandle TypeResolve { get; }
    }
}
