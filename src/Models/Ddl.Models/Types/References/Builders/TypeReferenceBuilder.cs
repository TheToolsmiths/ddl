using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Types.References.Locality;
using TheToolsmiths.Ddl.Models.Types.References.Storage;
using TheToolsmiths.Ddl.Models.Types.Resolution;
using TheToolsmiths.Ddl.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Models.Types.References.Builders
{
    public partial class TypeReferenceBuilder
    {
        private readonly Context context;

        internal TypeReferenceBuilder(Context context)
        {
            this.context = context;
        }

        public bool? IsRooted { get; set; }

        public List<TypeReferencePartBuilder> PathParts { get; } = new List<TypeReferencePartBuilder>();

        public TypeLocalityInformation Locality { get; set; } = TypeLocalityInformation.Local;

        public TypeStorage Storage { get; set; } = TypeStorage.SingleItem;

        public bool IsConstantModifier { get; set; }

        public static implicit operator TypeReference(TypeReferenceBuilder builder)
        {
            return builder.Build();
        }

        public static TypeReferenceBuilder Start() => new TypeReferenceBuilder(new Context());

        public TypeReference Build()
        {
            TypeReferencePath typePath = BuildPathParts();
            var modifiers = BuildTypeModifiers();

            var resolveState = new ResolveState(this.context.BuiltReferences);

            return new TypeReference(
                typePath,
                this.Storage,
                this.Locality,
                modifiers,
                ResolvedTypeKind.Unresolved,
                resolveState,
                TypeResolution.Unresolved);

            TypeModifiers BuildTypeModifiers()
            {
                if (this.IsConstantModifier)
                {
                    return new TypeModifiers(isConstant: true);
                }

                return TypeModifiers.None;
            }

            TypeReferencePath BuildPathParts()
            {
                var pathParts = new List<TypeReferencePathPart>();

                foreach (var partBuilder in this.PathParts)
                {
                    var part = partBuilder.Build();

                    pathParts.Add(part);
                }

                return this.IsRooted.GetValueOrDefault()
                     ? TypeReferencePath.CreateRootedFromParts(pathParts)
                     : TypeReferencePath.CreateFromParts(pathParts);
            }
        }

        public GenericPartBuilder StartsWithGenericPart(string genericIdentifier)
        {
            this.CheckCanStartPath();

            var genericPart = new GenericPartBuilder(genericIdentifier, this.context);

            this.PathParts.Add(genericPart);

            return genericPart;
        }

        public TypeReferenceBuilder StartsWithSimplePath(params string[] simpleIdentifiers)
        {
            return this.StartsWithSimplePath(false, simpleIdentifiers);
        }

        public TypeReferenceBuilder StartsRootedWithSimplePath(params string[] simpleIdentifiers)
        {
            return this.StartsWithSimplePath(true, simpleIdentifiers);
        }

        public TypeReferenceBuilder StartsWithGenericPath(string genericIdentifier, params string[] genericParameters)
        {
            return this.StartsWithGenericPath(false, genericIdentifier, genericParameters);
        }

        public TypeReferenceBuilder StartsRootedWithGenericPath(string genericIdentifier, params string[] genericParameters)
        {
            return this.StartsWithGenericPath(true, genericIdentifier, genericParameters);
        }

        private TypeReferenceBuilder StartsWithGenericPath(bool isRooted, string genericIdentifier, string[] genericParameters)
        {
            this.CheckCanStartPath();

            this.IsRooted = isRooted;

            var genericPart = new GenericPartBuilder(genericIdentifier, this.context);

            this.PathParts.Add(genericPart);

            foreach (string genericParameter in genericParameters)
            {
                genericPart.AddGenericParameter().StartsWithSimplePath(genericParameter);
            }

            return this;
        }

        private TypeReferenceBuilder StartsWithSimplePath(bool isRooted, string[] simpleIdentifiers)
        {
            this.CheckCanStartPath();

            this.IsRooted = isRooted;

            foreach (string simpleIdentifier in simpleIdentifiers)
            {
                this.PathParts.Add(new SimplePartBuilder(simpleIdentifier));
            }

            return this;
        }

        private void CheckCanStartPath()
        {
            if (this.PathParts.Count > 0)
            {
                throw new InvalidOperationException();
            }

            if (this.IsRooted.HasValue)
            {
                throw new InvalidOperationException();
            }
        }

        public GenericPartBuilder AddGenericPart(string genericIdentifier)
        {
            var genericPart = new GenericPartBuilder(genericIdentifier, this.context);

            this.PathParts.Add(genericPart);

            return genericPart;
        }

        public TypeReferenceBuilder AddSimplePath(params string[] simpleIdentifiers)
        {
            throw new NotImplementedException();
        }

        public TypeReferenceBuilder AddGenericPart(string genericIdentifier, params string[] genericParameters)
        {
            var genericPart = new GenericPartBuilder(genericIdentifier, this.context);

            this.PathParts.Add(genericPart);

            foreach (string genericParameter in genericParameters)
            {
                genericPart.AddGenericParameter().StartsWithSimplePath(genericParameter);
            }

            return this;
        }

        public TypeReferenceBuilder MakeConst()
        {
            this.IsConstantModifier = true;
            return this;
        }

        public TypeReferenceBuilder MakeArrayDynamicSized()
        {
            this.Storage = ArrayTypeStorage.DynamicSized;

            return this;
        }

        public TypeReferenceBuilder MakeArraySized(ArrayTypeStorage arrayStorage)
        {
            this.Storage = arrayStorage;

            return this;
        }

        public TypeReferenceBuilder SetOwnsReference()
        {
            this.Locality = TypeLocalityInformation.OwnsReference;

            return this;
        }

        public TypeReferenceBuilder SetHandleReference()
        {
            this.Locality = TypeLocalityInformation.HandleReference;

            return this;
        }

        public TypeReferenceBuilder SetRefReference()
        {
            this.Locality = TypeLocalityInformation.RefReference;

            return this;
        }

        public TypeReferenceBuilder SetArrayStorage(IReadOnlyList<ArraySize> sizes)
        {
            this.Storage = ArrayTypeStorage.CreateFromSizes(sizes);

            return this;
        }

        public TypeReferenceBuilder SetConstantModifier()
        {
            this.IsConstantModifier = true;

            return this;
        }
    }
}
