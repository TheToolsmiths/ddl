using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Models.Types.References.Builders;
using TheToolsmiths.Ddl.Models.Types.References.Storage;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Common;

using DynamicArraySize = TheToolsmiths.Ddl.Parser.Ast.Models.Arrays.DynamicArraySize;
using FixedArraySize = TheToolsmiths.Ddl.Parser.Ast.Models.Arrays.FixedArraySize;

namespace TheToolsmiths.Ddl.Parser.Build.Common.TypeHelpers
{
    public static class TypeReferenceCreator
    {
        public static TypeReference CreateFromTypeIdentifier(ITypeIdentifier typeIdentifier)
        {
            var builder = TypeReferenceBuilder.Start();

            BuildTypeIdentifier(builder, typeIdentifier);

            return builder.Build();
        }

        private static void BuildTypeIdentifier(TypeReferenceBuilder builder, ITypeIdentifier typeIdentifier)
        {
            switch (typeIdentifier)
            {
                case ConstantTypeIdentifier identifier:
                    BuildTypeIdentifier(builder, identifier);
                    break;
                case ArrayTypeIdentifier identifier:
                    BuildTypeIdentifier(builder, identifier);
                    break;
                case QualifiedTypeIdentifier identifier:
                    BuildTypeIdentifier(builder, identifier);
                    break;
                case ReferenceTypeIdentifier identifier:
                    BuildTypeIdentifier(builder, identifier);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeIdentifier));
            }
        }

        private static void BuildTypeIdentifier(
            TypeReferenceBuilder builder,
            ReferenceTypeIdentifier typeIdentifier)
        {
            switch (typeIdentifier.ReferenceKind)
            {
                case ReferenceKind.Owns:
                    builder.SetOwnsReference();
                    break;
                case ReferenceKind.Handle:
                    builder.SetHandleReference();
                    break;
                case ReferenceKind.Reference:
                    builder.SetRefReference();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            BuildTypeIdentifier(builder, typeIdentifier.TypeIdentifier);
        }

        private static void BuildTypeIdentifier(
            TypeReferenceBuilder builder,
            QualifiedTypeIdentifier typeIdentifier)
        {
            foreach (var identifierPathPart in typeIdentifier.TypePath.PathParts)
            {
                switch (identifierPathPart)
                {
                    case GenericIdentifierPathPart genericPart:
                        CreateGenericPathPart(genericPart);
                        break;
                    case SimpleIdentifierPathPart simplePart:
                        CreateSimplePathPart(simplePart);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(identifierPathPart));
                }
            }

            void CreateGenericPathPart(GenericIdentifierPathPart pathPart)
            {
                var genericPartBuilder = builder.AddGenericPart(pathPart.Name.Text);

                foreach (var parameterTypeIdentifier in pathPart.GenericParameters)
                {
                    var parameterBuilder = genericPartBuilder.AddGenericParameter();

                    BuildTypeIdentifier(parameterBuilder, parameterTypeIdentifier);
                }
            }

            void CreateSimplePathPart(SimpleIdentifierPathPart pathPart)
            {
                builder.AddSimplePath(pathPart.Name.Text);
            }
        }

        private static void BuildTypeIdentifier(TypeReferenceBuilder builder, ArrayTypeIdentifier typeIdentifier)
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

            builder.SetArrayStorage(sizes);

            BuildTypeIdentifier(builder, typeIdentifier.TypeIdentifier);

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

                ArraySize value = new Models.Types.References.Storage.FixedArraySize(dimensions);

                return Result.FromValue(value);
            }

            Result<ArraySize> CreateDynamicSize(DynamicArraySize _)
            {
                ArraySize value = new Models.Types.References.Storage.DynamicArraySize();

                return Result.FromValue(value);
            }
        }

        private static void BuildTypeIdentifier(
            TypeReferenceBuilder builder,
            ConstantTypeIdentifier typeIdentifier)
        {
            builder.SetConstantModifier();

            BuildTypeIdentifier(builder, typeIdentifier.TypeIdentifier);
        }
    }
}
