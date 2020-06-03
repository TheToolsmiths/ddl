using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Parser.Models.Types.References
{
    public class TypeReference
    {
        public TypeReference(
            TypeReferencePath typePath,
            TypeStorage storage,
            LocalityInformation locality,
            TypeModifiers modifiers,
            ResolvedTypeKind resolvedKind,
            ResolveState resolveState)
        {
            this.TypePath = typePath;
            this.Storage = storage;
            this.Locality = locality;
            this.Modifiers = modifiers;
            this.ResolvedKind = resolvedKind;
            this.ResolveState = resolveState;
        }

        public TypeReferencePath TypePath { get; }

        public TypeStorage Storage { get; }

        public LocalityInformation Locality { get; }

        public TypeModifiers Modifiers { get; }

        public ResolvedTypeKind ResolvedKind { get; }

        public ResolveState ResolveState { get; }
    }
}
