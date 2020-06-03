using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Parser.Models.Types.References;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Resolve.Common.TypeHelpers
{
    public class TypeReferenceBuilder
    {
        public TypeReferenceBuilder()
        {
            this.ResolvedKind = ResolvedTypeKind.Unresolved;
            this.Locality = LocalityInformation.Local;
        }

        public ResolveState? ResolveState { get; set; }

        public ResolvedTypeKind ResolvedKind { get; set; }

        public LocalityInformation Locality { get; set; }

        public TypeStorage? Storage { get; set; }

        public TypeReferencePath? TypePath { get; set; }

        public bool IsConstantModifier { get; set; }

        public TypeReference Build()
        {
            var typePath = this.TypePath ?? throw new ArgumentException();
            var storage = this.Storage ?? throw new ArgumentException();
            var locality = this.Locality ?? throw new ArgumentException();
            var modifiers = new TypeModifiers();
            var resolveState = this.ResolveState ?? throw new ArgumentException();

            return new TypeReference(
                typePath,
                storage,
                locality,
                modifiers,
                this.ResolvedKind,
                resolveState);
        }

        public void SetOwnsReference()
        {
            this.Locality = LocalityInformation.OwnsReference;
        }

        public void SetHandleReference()
        {
            this.Locality = LocalityInformation.HandleReference;
        }

        public void SetRefReference()
        {
            this.Locality = LocalityInformation.RefReference;
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
