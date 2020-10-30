using System;
using System.Globalization;

using TheToolsmiths.Ddl.Models.Types.Paths;
using TheToolsmiths.Ddl.Models.Types.Usage;
using TheToolsmiths.Ddl.Models.Types.Usage.Locality;
using TheToolsmiths.Ddl.Models.Types.Usage.Modifiers;
using TheToolsmiths.Ddl.Models.Types.Usage.Storage;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Types
{
    public class TypeUseWriter
    {
        public Result Write(ICompiledEntryWriterContext context, TypeUse typeUse)
        {
            context.Writer.WriteStartObject();

            this.WriteTypePath(context, typeUse.TypePath);

            this.WriteTypeUseLocality(context, typeUse.Locality);

            this.WriteTypeUseModifiers(context, typeUse.Modifiers);

            this.WriteTypeUseStorage(context, typeUse.Storage);

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteTypePath(ICompiledEntryWriterContext context, TypePath typePath)
        {
            context.Writer.WriteStartObject("path");

            context.Writer.WriteBoolean("isRooted", typePath.IsRooted);

            context.Writer.WriteStartArray("parts");

            foreach (var pathPart in typePath.PathParts)
            {
                var result = WritePathPart(pathPart);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            context.Writer.WriteEndArray();

            context.Writer.WriteEndObject();

            return Result.Success;

            Result WritePathPart(TypePathPart pathPart)
            {
                context.Writer.WriteStartObject();

                var result = pathPart switch
                {
                    GenericPathPart genericPathPart => WriteGenericPathPart(genericPathPart),
                    SimplePathPart simplePathPart => WriteSimplePathPart(simplePathPart),
                    _ => throw new ArgumentOutOfRangeException(nameof(pathPart))
                };

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                context.Writer.WriteEndObject();

                return result;

                Result WriteSimplePathPart(SimplePathPart simplePart)
                {
                    context.Writer.WriteString("kind", "simple");

                    context.Writer.WriteString("name", simplePart.Name);

                    return Result.Success;
                }

                Result WriteGenericPathPart(GenericPathPart genericPart)
                {
                    context.Writer.WriteString("kind", "generic");

                    context.Writer.WriteString("name", genericPart.Name);

                    context.Writer.WriteStartArray("parameters");

                    foreach (var genericParameter in genericPart.ParameterTypes)
                    {
                        var genericParameterResult = context.CommonWriters.WriteTypeUse(genericParameter);

                        if (genericParameterResult.IsError)
                        {
                            throw new NotImplementedException();
                        }
                    }

                    context.Writer.WriteEndArray();

                    return Result.Success;
                }
            }
        }

        public Result WriteTypeUseLocality(ICompiledEntryWriterContext context, TypeUseLocality locality)
        {
            string localityKind = locality.LocalityKind switch
            {
                LocalityKind.Local => "local",
                LocalityKind.Reference => locality.ReferenceKind switch
                {
                    LocalityReferenceKind.Reference => "reference",
                    LocalityReferenceKind.Owns => "owns",
                    LocalityReferenceKind.Handle => "handle",
                    _ => throw new ArgumentOutOfRangeException()
                },
                _ => throw new ArgumentOutOfRangeException()
            };

            context.Writer.WriteString("locality", localityKind);

            return Result.Success;
        }

        public Result WriteTypeUseModifiers(ICompiledEntryWriterContext context, TypeUseModifiers modifiers)
        {
            if (modifiers.IsConstant == false)
            {
                return Result.Success;
            }

            context.Writer.WriteStartObject("modifiers");

            context.Writer.WriteBoolean("isConstant", true);

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        public Result WriteTypeUseStorage(ICompiledEntryWriterContext context, TypeUseStorage storage)
        {
            context.Writer.WriteStartObject("storage");

            switch (storage)
            {
                case ArrayTypeUseStorage arrayStorage:
                    WriteArrayStorage(arrayStorage);
                    break;
                case SingleItemTypeUseStorage singleItemStorage:
                    WriteSingleItemStorage(singleItemStorage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(storage));
            }

            context.Writer.WriteEndObject();

            return Result.Success;

            void WriteArrayStorage(ArrayTypeUseStorage arrayStorage)
            {
                context.Writer.WriteString("kind", "array");

                string sizesKind = arrayStorage.IsFixed ? "fixed" : "dynamic";
                context.Writer.WriteString("arrayKind", sizesKind);

                context.Writer.WriteStartArray("sizes");

                foreach (var arraySize in arrayStorage.Sizes)
                {
                    context.Writer.WriteStartObject();

                    switch (arraySize)
                    {
                        case DynamicArraySize dynamicArraySize:
                            WriteDynamicArraySize(dynamicArraySize);
                            break;
                        case FixedArraySize fixedArraySize:
                            WriteFixedArraySize(fixedArraySize);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(arraySize));
                    }

                    context.Writer.WriteEndObject();
                }

                context.Writer.WriteEndArray();

                void WriteDynamicArraySize(DynamicArraySize _)
                {
                    context.Writer.WriteString("kind", "dynamic");
                }

                void WriteFixedArraySize(FixedArraySize arraySize)
                {
                    context.Writer.WriteString("kind", "fixed");

                    context.Writer.WriteStartArray("dimensions");

                    foreach (int dimension in arraySize.Dimensions)
                    {
                        context.Writer.WriteStringValue(dimension.ToString(NumberFormatInfo.InvariantInfo));
                    }

                    context.Writer.WriteEndArray();
                }
            }

            void WriteSingleItemStorage(SingleItemTypeUseStorage _)
            {
                context.Writer.WriteString("kind", "single");
            }
        }
    }
}
