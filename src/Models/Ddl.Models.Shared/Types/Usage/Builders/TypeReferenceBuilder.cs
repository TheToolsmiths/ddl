﻿using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Types.Paths;
using TheToolsmiths.Ddl.Models.Types.Usage.Locality;
using TheToolsmiths.Ddl.Models.Types.Usage.Modifiers;
using TheToolsmiths.Ddl.Models.Types.Usage.Storage;

namespace TheToolsmiths.Ddl.Models.Types.Usage.Builders
{
    public class TypeReferenceBuilder
    {
        public bool? IsRooted { get; set; }

        public List<TypeReferencePartBuilder> PathParts { get; } = new List<TypeReferencePartBuilder>();

        public TypeUseLocality Locality { get; set; } = TypeUseLocality.Local;

        public TypeUseStorage Storage { get; set; } = TypeUseStorage.SingleItem;

        public bool IsConstantModifier { get; set; }

        public static TypeReferenceBuilder Start() => new TypeReferenceBuilder();

        public TypeUse Build()
        {
            var typePath = BuildPathParts();

            var modifiers = BuildTypeModifiers();

            var typeReference = new TypeUse(
                typePath,
                this.Storage,
                this.Locality,
                modifiers);

            return typeReference;

            TypeUseModifiers BuildTypeModifiers()
            {
                if (this.IsConstantModifier)
                {
                    return new TypeUseModifiers(true);
                }

                return TypeUseModifiers.None;
            }

            TypePath BuildPathParts()
            {
                var pathParts = new List<TypePathPart>();

                foreach (var partBuilder in this.PathParts)
                {
                    var part = partBuilder.Build();

                    pathParts.Add(part);
                }

                return this.IsRooted.GetValueOrDefault()
                     ? TypePath.CreateRootedFromParts(pathParts)
                     : TypePath.CreateFromParts(pathParts);
            }

        }

        public GenericPartBuilder StartsWithGenericPart(string genericIdentifier)
        {
            this.CheckCanStartPath();

            var genericPart = new GenericPartBuilder(genericIdentifier);

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

            var genericPart = new GenericPartBuilder(genericIdentifier);

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
            var genericPart = new GenericPartBuilder(genericIdentifier);

            this.PathParts.Add(genericPart);

            return genericPart;
        }

        public void AddSimplePath(string name)
        {
            var simplePart = new SimplePartBuilder(name);

            this.PathParts.Add(simplePart);
        }

        public TypeReferenceBuilder AddGenericPart(string genericIdentifier, params string[] genericParameters)
        {
            var genericPart = new GenericPartBuilder(genericIdentifier);

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
            this.Storage = TypeUseStorage.DynamicSized;

            return this;
        }

        public TypeReferenceBuilder MakeArraySized(ArrayTypeUseStorage arrayStorage)
        {
            this.Storage = arrayStorage;

            return this;
        }

        public TypeReferenceBuilder SetOwnsReference()
        {
            this.Locality = TypeUseLocality.OwnsReference;

            return this;
        }

        public TypeReferenceBuilder SetHandleReference()
        {
            this.Locality = TypeUseLocality.HandleReference;

            return this;
        }

        public TypeReferenceBuilder SetRefReference()
        {
            this.Locality = TypeUseLocality.RefReference;

            return this;
        }

        public TypeReferenceBuilder SetArrayStorage(IReadOnlyList<ArraySize> sizes)
        {
            this.Storage = ArrayTypeUseStorage.CreateFromSizes(sizes);

            return this;
        }

        public TypeReferenceBuilder SetConstantModifier()
        {
            this.IsConstantModifier = true;

            return this;
        }
    }
}