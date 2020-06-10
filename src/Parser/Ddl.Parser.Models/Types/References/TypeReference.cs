using TheToolsmiths.Ddl.Parser.Models.Types.Resolution;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Parser.Models.Types.References
{
    public class TypeReference
    {
        public TypeReference(
            TypeReferencePath typePath,
            TypeStorage storage,
            TypeLocalityInformation locality,
            TypeModifiers modifiers,
            ResolvedTypeKind resolvedKind,
            ResolveState resolveState,
            TypeResolution typeResolution)
        {
            this.TypePath = typePath;
            this.Storage = storage;
            this.Locality = locality;
            this.Modifiers = modifiers;
            this.ResolvedKind = resolvedKind;
            this.ResolveState = resolveState;
            this.TypeResolution = typeResolution;
        }

        public TypeReferencePath TypePath { get; }

        public TypeStorage Storage { get; }

        public TypeLocalityInformation Locality { get; }

        public TypeModifiers Modifiers { get; }

        public ResolvedTypeKind ResolvedKind { get; }

        public ResolveState ResolveState { get; }

        public TypeResolution TypeResolution { get; }

        public TypeReference WithTypeResolution(TypeResolution typeResolution)
        {
            return new TypeReference(
                this.TypePath,
                this.Storage,
                this.Locality,
                this.Modifiers,
                this.ResolvedKind,
                this.ResolveState,
                typeResolution);
        }

        public TypeReference WithResolvedKind(ResolvedTypeKind resolvedKind)
        {
            return new TypeReference(
                this.TypePath,
                this.Storage,
                this.Locality,
                this.Modifiers,
                resolvedKind,
                this.ResolveState,
                this.TypeResolution);
        }
    }
}
