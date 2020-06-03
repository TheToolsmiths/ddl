using System;
using System.Collections.Generic;

using Ddl.Common;

using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Common;
using TheToolsmiths.Ddl.Parser.Models.Types.References;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References;

using DynamicArraySize = TheToolsmiths.Ddl.Parser.Ast.Models.Arrays.DynamicArraySize;
using FixedArraySize = TheToolsmiths.Ddl.Parser.Ast.Models.Arrays.FixedArraySize;

namespace TheToolsmiths.Ddl.Resolve.Common.TypeHelpers
{
    public static class TypeReferenceCreator
    {
        private class TypeIdentifierBuildContext
        {
            private readonly List<TypeIdentifierBuildContext> typesToResolve;

            public TypeIdentifierBuildContext(
                List<TypeIdentifierBuildContext> typesToResolve,
                ITypeIdentifier typeIdentifier)
            {
                this.TypeIdentifier = typeIdentifier;
                this.Builder = new TypeReferenceBuilder();
                this.typesToResolve = typesToResolve;
            }

            public ITypeIdentifier TypeIdentifier { get; }

            public TypeReferenceBuilder Builder { get; }

            public int EnqueueTypeIdentifier(IGenericParameterTypeIdentifier typeIdentifier)
            {
                var context = new TypeIdentifierBuildContext(this.typesToResolve, typeIdentifier);

                this.typesToResolve.Add(context);

                return this.typesToResolve.Count - 1;
            }
        }

        public static TypeReference CreateFromTypeIdentifier(ITypeIdentifier typeIdentifier)
        {
            var typesToResolve = new List<TypeIdentifierBuildContext>();

            typesToResolve.Add(new TypeIdentifierBuildContext(typesToResolve, typeIdentifier));

            for (int i = 0; i < typesToResolve.Count; i++)
            {
                var context = typesToResolve[i];

                var type = context.TypeIdentifier;

                BuildTypeIdentifier(context, type);

                var foo = context.Builder.Build();
            }

            throw new NotImplementedException();
        }

        private static void BuildTypeIdentifier(TypeIdentifierBuildContext context, ITypeIdentifier typeIdentifier)
        {
            switch (typeIdentifier)
            {
                case ConstantTypeIdentifier identifier:
                    BuildTypeIdentifier(context, identifier);
                    break;
                case ArrayTypeIdentifier identifier:
                    BuildTypeIdentifier(context, identifier);
                    break;
                case QualifiedTypeIdentifier identifier:
                    BuildTypeIdentifier(context, identifier);
                    break;
                case ReferenceTypeIdentifier identifier:
                    BuildTypeIdentifier(context, identifier);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeIdentifier));
            }
        }

        private static void BuildTypeIdentifier(TypeIdentifierBuildContext context, ReferenceTypeIdentifier typeIdentifier)
        {
            switch (typeIdentifier.ReferenceKind)
            {
                case ReferenceKind.Owns:
                    context.Builder.SetOwnsReference();
                    break;
                case ReferenceKind.Handle:
                    context.Builder.SetHandleReference();
                    break;
                case ReferenceKind.Reference:
                    context.Builder.SetRefReference();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            BuildTypeIdentifier(context, typeIdentifier.TypeIdentifier);
        }

        private static void BuildTypeIdentifier(TypeIdentifierBuildContext context, QualifiedTypeIdentifier typeIdentifier)
        {
            var referencePath = BuildTypeIdentifierPath(typeIdentifier.TypePath);

            context.Builder.SetTypePath(referencePath);

            TypeReferencePath BuildTypeIdentifierPath(TypeIdentifierPath typePath)
            {
                var pathParts = new List<TypeReferencePathPart>();

                foreach (var identifierPathPart in typePath.PathParts)
                {
                    TypeReferencePathPart pathPart = identifierPathPart switch
                    {
                        GenericIdentifierPathPart part => CreateGenericPathPart(part),
                        SimpleIdentifierPathPart part => CreateSimplePathPart(part),
                        _ => throw new ArgumentOutOfRangeException(nameof(identifierPathPart))
                    };

                    pathParts.Add(pathPart);
                }

                return new TypeReferencePath(typePath.IsRooted, pathParts);

                TypeReferencePathPart CreateGenericPathPart(GenericIdentifierPathPart pathPart)
                {
                    var typesIndices = new List<int>();

                    foreach (var parameterTypeIdentifier in pathPart.GenericParameters)
                    {
                        int typeIndex = context.EnqueueTypeIdentifier(parameterTypeIdentifier);

                        typesIndices.Add(typeIndex);
                    }

                    return new GenericReferencePathPart(pathPart.Name, pathPart.GenericParameters.Count, typesIndices);
                }

                TypeReferencePathPart CreateSimplePathPart(SimpleIdentifierPathPart pathPart)
                {
                    return new SimpleReferencePathPart(pathPart.Name);
                }
            }
        }

        private static void BuildTypeIdentifier(TypeIdentifierBuildContext context, ArrayTypeIdentifier typeIdentifier)
        {
            List<ArraySize> sizes = new List<ArraySize>();

            foreach (var typeIdentifierSize in typeIdentifier.Sizes)
            {
                var result = typeIdentifierSize switch
                {
                    DynamicArraySize dynamicArraySize => CreateDynamicSize(dynamicArraySize),
                    FixedArraySize fixedArraySize => CreateFixedSize(fixedArraySize),
                    _ => throw new ArgumentOutOfRangeException(nameof(typeIdentifierSize))
                };

                sizes.Add(result.Value);
            }

            context.Builder.SetArrayStorage(sizes);

            BuildTypeIdentifier(context, typeIdentifier.TypeIdentifier);

            Result<ArraySize> CreateFixedSize(FixedArraySize fixedArraySize)
            {
                var dimensions = new List<int>();

                foreach (var numberLiteral in fixedArraySize.Dimensions)
                {
                    if (NumberLiteralParser.TryParseInteger(numberLiteral, out int integer) == false)
                    {
                        return Result.FromErrorMessage<ArraySize>($"Cannot parse '{numberLiteral.Text}' as integer");
                    }

                    dimensions.Add(integer);
                }

                ArraySize value = new Parser.Models.Types.References.FixedArraySize(dimensions);

                return Result.FromValue(value);
            }

            Result<ArraySize> CreateDynamicSize(DynamicArraySize _)
            {
                ArraySize value = new Parser.Models.Types.References.DynamicArraySize();

                return Result.FromValue(value);
            }
        }

        private static void BuildTypeIdentifier(TypeIdentifierBuildContext context, ConstantTypeIdentifier typeIdentifier)
        {
            context.Builder.SetConstantModifier();

            BuildTypeIdentifier(context, typeIdentifier.TypeIdentifier);
        }
    }
}
