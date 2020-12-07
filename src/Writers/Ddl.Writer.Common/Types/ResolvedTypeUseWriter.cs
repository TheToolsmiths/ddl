using System;

using TheToolsmiths.Ddl.Models.Compiled.Items.References;
using TheToolsmiths.Ddl.Models.Compiled.Types.Resolution;
using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Usage;
using TheToolsmiths.Ddl.Models.Types.Usage.Locality;
using TheToolsmiths.Ddl.Models.Types.Usage.Modifiers;
using TheToolsmiths.Ddl.Models.Types.Usage.Storage;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Types
{
    public class ResolvedTypeUseWriter
    {
        public Result Write(ICompiledEntryWriterContext context, ResolvedTypeUse typeUse)
        {
            context.Writer.WriteStartObject();

            this.WriteTypeUse(context, typeUse.TypeUse);

            this.WriteTypeResolution(context, typeUse.TypeResolution);

            this.WriteLocality(context, typeUse.Locality);

            this.WriteModifiers(context, typeUse.Modifiers);

            this.WriteStorage(context, typeUse.Storage);

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteTypeResolution(ICompiledEntryWriterContext context, TypeResolution typeResolution)
        {
            context.Writer.WriteStartObject("resolution");

            var result = typeResolution switch
            {
                GenericParameterResolution genericParameter => this.WriteGenericParameterResolution(context, genericParameter),
                MatchImportResolution matchImport => this.WriteImportResolution(context, matchImport),
                ResolvedBuiltinType builtinType => this.WriteBuiltinResolution(context, builtinType),
                ResolvedNamespace resolvedNamespace => this.WriteNamespaceResolution(context, resolvedNamespace),
                ResolvedType resolvedType => this.WriteResolvedTypeResolution(context, resolvedType),
                UnresolvedType unresolvedType => this.WriteUnresolved(context, unresolvedType),
                _ => throw new ArgumentOutOfRangeException(nameof(typeResolution))
            };

            context.Writer.WriteEndObject();

            return result;
        }

        private Result WriteUnresolved(ICompiledEntryWriterContext context, UnresolvedType unresolvedType)
        {
            context.Writer.WriteString("kind", "unresolved");

            return Result.Success;
        }

        private Result WriteTypeUse(ICompiledEntryWriterContext context, TypeUse typeUse)
        {
            context.Writer.WritePropertyName("typePath");

            return context.CommonWriters.WriteTypeUse(typeUse);
        }

        private Result WriteResolvedTypeResolution(ICompiledEntryWriterContext context, ResolvedType resolvedType)
        {
            context.Writer.WriteString("kind", "resolved");

            switch (resolvedType.EntityReference)
            {
                case ItemReference itemReference:
                    {
                        context.Writer.WriteString("ref-kind", "item");

                        if (!context.EntityKeyMap.TryGetItemKey(itemReference, out var itemKey))
                        {
                            throw new NotImplementedException();
                        }

                        context.Writer.WriteNumber("itemId", itemReference.ItemId.ToInt());
                        context.Writer.WriteString("item", itemKey);
                    }
                    break;
                case SubItemReference subItemReference:
                    {
                        context.Writer.WriteString("ref-kind", "sub-item");

                        if (!context.EntityKeyMap.TryGetItemKey(subItemReference, out var itemKey, out var subItemKey))
                        {
                            throw new NotImplementedException();
                        }

                        context.Writer.WriteNumber("itemId", subItemReference.ItemId.ToInt());
                        context.Writer.WriteNumber("subItemId", subItemReference.SubItemId.ToInt());
                        context.Writer.WriteString("item", itemKey);
                        context.Writer.WriteString("subItem", subItemKey);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Result.Success;
        }

        private Result WriteNamespaceResolution(ICompiledEntryWriterContext context, ResolvedNamespace resolvedNamespace)
        {
            throw new NotImplementedException();
        }

        private Result WriteBuiltinResolution(ICompiledEntryWriterContext context, ResolvedBuiltinType builtinType)
        {
            context.Writer.WriteString("kind", "builtin");

            string dimension = builtinType.TypeDimension switch
            {
                BuiltinTypeDimension.Scalar => "scalar",
                BuiltinTypeDimension.Vector => "vector",
                BuiltinTypeDimension.Matrix => "matrix",
                _ => throw new ArgumentOutOfRangeException()
            };

            context.Writer.WriteString("dimension-kind", dimension);

            string typeKind = builtinType.TypeKind switch
            {
                BuiltinTypeKind.Bool => "bool",
                BuiltinTypeKind.UInt8 => "uint8",
                BuiltinTypeKind.Int8 => "int8",
                BuiltinTypeKind.UInt16 => "uint16",
                BuiltinTypeKind.Int16 => "int16",
                BuiltinTypeKind.UInt32 => "uin32",
                BuiltinTypeKind.Int32 => "int32",
                BuiltinTypeKind.UInt64 => "uint64",
                BuiltinTypeKind.Int64 => "int64",
                BuiltinTypeKind.Float32 => "float32",
                BuiltinTypeKind.Float64 => "float64",
                BuiltinTypeKind.Char => "char",
                BuiltinTypeKind.String => "string",
                _ => throw new ArgumentOutOfRangeException()
            };

            context.Writer.WriteString("type", typeKind);

            switch (builtinType)
            {
                case ResolvedMatrixType matrix:
                    {
                        context.Writer.WriteNumber("columns", matrix.ColumnSize);
                        context.Writer.WriteNumber("rows", matrix.RowSize);
                    }
                    break;
                case ResolvedScalarType _:
                    break;
                case ResolvedVectorType vector:
                    {
                        context.Writer.WriteNumber("size", vector.VectorSize);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(builtinType));
            }

            return Result.Success;
        }

        private Result WriteImportResolution(ICompiledEntryWriterContext context, MatchImportResolution matchImport)
        {
            context.Writer.WriteString("kind", "import");

            var result = this.WriteTypeResolution(context, matchImport.ImportPathTypeResolution);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return Result.Success;
        }

        private Result WriteGenericParameterResolution(ICompiledEntryWriterContext context, GenericParameterResolution genericParameter)
        {
            context.Writer.WriteString("kind", "generic-param");

            context.Writer.WriteString("param-name", genericParameter.ParameterName);

            return Result.Success;
        }

        private Result WriteStorage(ICompiledEntryWriterContext context, TypeUseStorage storage)
        {
            return context.CommonWriters.WriteTypeUseStorage(storage);
        }

        private Result WriteLocality(ICompiledEntryWriterContext context, TypeUseLocality locality)
        {
            return context.CommonWriters.WriteTypeUseLocality(locality);
        }

        private Result WriteModifiers(ICompiledEntryWriterContext context, TypeUseModifiers modifiers)
        {
            return context.CommonWriters.WriteTypeUseModifiers(modifiers);
        }

        private void WriteIdentifier(ICompiledEntryWriterContext context, TypeNameIdentifier identifier)
        {
            switch (identifier)
            {
                case GenericTypeNameIdentifier genericIdentifier:
                    this.WriteGenericIdentifier(context, genericIdentifier);
                    break;
                case SimpleTypeNameIdentifier simpleIdentifier:
                    this.WriteSimpleIdentifier(context, simpleIdentifier);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(identifier));
            }
        }

        private void WriteSimpleIdentifier(ICompiledEntryWriterContext context, SimpleTypeNameIdentifier identifier)
        {
            context.Writer.WriteString("name", identifier.Name);
            context.Writer.WriteString("kind", "simple");
        }

        private void WriteGenericIdentifier(ICompiledEntryWriterContext context, GenericTypeNameIdentifier identifier)
        {
            context.Writer.WriteString("name", identifier.Name);
            context.Writer.WriteString("kind", "generic");

            context.Writer.WriteStartArray("parameters");

            foreach (var genericParameter in identifier.GenericParameters)
            {
                context.Writer.WriteStartObject();

                context.Writer.WriteString("name", genericParameter.Text);

                context.Writer.WriteEndObject();
            }

            context.Writer.WriteEndArray();
        }
    }
}
