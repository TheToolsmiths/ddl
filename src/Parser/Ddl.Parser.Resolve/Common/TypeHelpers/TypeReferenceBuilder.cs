using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Parser.Models.Types.References;
using TheToolsmiths.Ddl.Parser.Models.Types.Resolved;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Resolve.Common.TypeHelpers
{
    public class TypeReferenceBuilder
    {
        public TypeReferenceBuilder()
        {
            this.ResolvedKind = ResolvedTypeKind.Unresolved;
            this.Locality = TypeLocalityInformation.Local;
            this.Storage = new SingleItemTypeStorage();

            this.GenericParameterTypes = new List<TypeReference>();
        }

        public List<TypeReference> GenericParameterTypes { get; }

        public ResolvedTypeKind ResolvedKind { get; set; }

        public TypeLocalityInformation Locality { get; set; }

        public TypeStorage Storage { get; set; }

        public TypeReferencePath? TypePath { get; set; }

        public bool IsConstantModifier { get; set; }

        public IReadOnlyList<TypeReference>? BuiltReferences { get; set; }

        public TypeReference Build()
        {
            var typePath = this.TypePath ?? throw new ArgumentException();
            var storage = this.Storage ?? throw new ArgumentException();
            var locality = this.Locality ?? throw new ArgumentException();
            var builtReferences = this.BuiltReferences ?? throw new ArgumentException();
            var modifiers = this.BuildTypeModifiers();
            
            var resolveState = new ResolveState(builtReferences);

            return new TypeReference(
                typePath,
                storage,
                locality,
                modifiers,
                this.ResolvedKind,
                resolveState,
                TypeResolution.Unresolved);
        }

        private TypeModifiers BuildTypeModifiers()
        {
            if (this.IsConstantModifier)
            {
                return new TypeModifiers(isConstant: true);
            }

            return TypeModifiers.None;
        }

        public void SetOwnsReference()
        {
            this.Locality = TypeLocalityInformation.OwnsReference;
        }

        public void SetHandleReference()
        {
            this.Locality = TypeLocalityInformation.HandleReference;
        }

        public void SetRefReference()
        {
            this.Locality = TypeLocalityInformation.RefReference;
        }

        public void SetArrayStorage(IReadOnlyList<ArraySize> sizes)
        {
            this.Storage = ArrayTypeStorage.CreateFromSizes(sizes);
        }

        public void SetConstantModifier()
        {
            this.IsConstantModifier = true;
        }

        public void SetTypePath(TypeReferencePath typePath)
        {
            this.TypePath = typePath;
        }
    }
}
