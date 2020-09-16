using System;
using System.Globalization;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Resolution;
using TheToolsmiths.Ddl.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences
{
    public class BuiltinTypeReferenceResolver
    {
        public bool TryResolveBuiltinType(TypeReferencePath typePath, out TypeResolution typeResolution)
        {
            // If type path is rooted, assume it can't be a builtin type
            if (typePath.IsRooted)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            // If type path has no parts, it's also not a builtin type
            if (typePath.PathParts.Length == 0)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            ref readonly var initialPart = ref typePath.PathParts.Span[0];

            // We don't have generic builtin types for now
            if (initialPart.PartKind == TypeNameKind.Generic)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            switch (initialPart.Name)
            {
                case BuiltinTypeNames.Bool:
                    typeResolution = BuiltinTypeResolutions.Bool;
                    return true;

                case BuiltinTypeNames.UInt8:
                    typeResolution = BuiltinTypeResolutions.UInt8;
                    return true;

                case BuiltinTypeNames.Int8:
                    typeResolution = BuiltinTypeResolutions.Int8;
                    return true;

                case BuiltinTypeNames.UInt16:
                    typeResolution = BuiltinTypeResolutions.UInt16;
                    return true;

                case BuiltinTypeNames.Int16:
                    typeResolution = BuiltinTypeResolutions.Int16;
                    return true;

                case BuiltinTypeNames.UInt32:
                    typeResolution = BuiltinTypeResolutions.UInt32;
                    return true;

                case BuiltinTypeNames.Int32:
                    typeResolution = BuiltinTypeResolutions.Int32;
                    return true;

                case BuiltinTypeNames.UInt64:
                    typeResolution = BuiltinTypeResolutions.UInt64;
                    return true;

                case BuiltinTypeNames.Int64:
                    typeResolution = BuiltinTypeResolutions.Int64;
                    return true;

                case BuiltinTypeNames.Float32:
                    typeResolution = BuiltinTypeResolutions.Float32;
                    return true;

                case BuiltinTypeNames.Float64:
                    typeResolution = BuiltinTypeResolutions.Float64;
                    return true;

                case BuiltinTypeNames.Char:
                    typeResolution = BuiltinTypeResolutions.Char;
                    return true;

                case BuiltinTypeNames.String:
                    typeResolution = BuiltinTypeResolutions.String;
                    return true;
            }

            // Check for vector prefix
            if (initialPart.Name.StartsWith(BuiltinTypeNames.VectorPrefix, StringComparison.Ordinal))
            {
                if (this.TryResolveVectorType(typePath, out typeResolution))
                {
                    return true;
                }
            }

            // Check for matrix prefix
            if (initialPart.Name.StartsWith(BuiltinTypeNames.VectorPrefix, StringComparison.Ordinal))
            {
                if (this.TryResolveMatrixType(typePath, out typeResolution))
                {
                    return true;
                }
            }


            typeResolution = TypeResolution.Unresolved;
            return false;
        }

        private bool TryResolveVectorType(TypeReferencePath typePath, out TypeResolution typeResolution)
        {
            if (typePath.PathParts.Length != 2)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            ref readonly var vectorPart = ref typePath.PathParts.Span[0];

            ref readonly var typePart = ref typePath.PathParts.Span[1];

            if (vectorPart.PartKind == TypeNameKind.Generic ||
                vectorPart.PartKind == TypeNameKind.Generic)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            var vecSizeSpan = vectorPart.Name.AsSpan().Slice(BuiltinTypeNames.VectorPrefix.Length);

            if (int.TryParse(vecSizeSpan, NumberStyles.None, CultureInfo.InvariantCulture, out int vectorSize) == false)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            if (vectorSize <= 0 || vectorSize > 4)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            if (TryParseBuiltinTypeKind(typePart.Name, out var builtinType) == false)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            typeResolution = new VectorBuiltinType(builtinType, vectorSize);
            return true;
        }

        private bool TryResolveMatrixType(TypeReferencePath typePath, out TypeResolution typeResolution)
        {
            throw new NotImplementedException();
        }

        private static bool TryParseBuiltinTypeKind(string typeName, out BuiltinTypeKind builtinTypeKind)
        {
            switch (typeName)
            {
                case BuiltinTypeNames.Bool:
                    builtinTypeKind = BuiltinTypeKind.Bool;
                    return true;

                case BuiltinTypeNames.UInt8:
                    builtinTypeKind = BuiltinTypeKind.UInt8;
                    return true;

                case BuiltinTypeNames.Int8:
                    builtinTypeKind = BuiltinTypeKind.Int8;
                    return true;

                case BuiltinTypeNames.UInt16:
                    builtinTypeKind = BuiltinTypeKind.UInt16;
                    return true;

                case BuiltinTypeNames.Int16:
                    builtinTypeKind = BuiltinTypeKind.Int16;
                    return true;

                case BuiltinTypeNames.UInt32:
                    builtinTypeKind = BuiltinTypeKind.UInt32;
                    return true;

                case BuiltinTypeNames.Int32:
                    builtinTypeKind = BuiltinTypeKind.Int32;
                    return true;

                case BuiltinTypeNames.UInt64:
                    builtinTypeKind = BuiltinTypeKind.UInt64;
                    return true;

                case BuiltinTypeNames.Int64:
                    builtinTypeKind = BuiltinTypeKind.Int64;
                    return true;

                case BuiltinTypeNames.Float32:
                    builtinTypeKind = BuiltinTypeKind.Float32;
                    return true;

                case BuiltinTypeNames.Float64:
                    builtinTypeKind = BuiltinTypeKind.Float64;
                    return true;

                case BuiltinTypeNames.Char:
                    builtinTypeKind = BuiltinTypeKind.Char;
                    return true;

                case BuiltinTypeNames.String:
                    builtinTypeKind = BuiltinTypeKind.String;
                    return true;
            }

            builtinTypeKind = default;
            return false;
        }
    }

    public static class BuiltinTypeResolutions
    {
        public static TypeResolution Bool { get; } = new ScalarBuiltinType(BuiltinTypeKind.Bool);

        public static TypeResolution UInt8 { get; } = new ScalarBuiltinType(BuiltinTypeKind.UInt8);

        public static TypeResolution Int8 { get; } = new ScalarBuiltinType(BuiltinTypeKind.Int8);

        public static TypeResolution UInt16 { get; } = new ScalarBuiltinType(BuiltinTypeKind.UInt16);

        public static TypeResolution Int16 { get; } = new ScalarBuiltinType(BuiltinTypeKind.Int16);

        public static TypeResolution UInt32 { get; } = new ScalarBuiltinType(BuiltinTypeKind.UInt32);

        public static TypeResolution Int32 { get; } = new ScalarBuiltinType(BuiltinTypeKind.Int32);

        public static TypeResolution UInt64 { get; } = new ScalarBuiltinType(BuiltinTypeKind.UInt64);

        public static TypeResolution Int64 { get; } = new ScalarBuiltinType(BuiltinTypeKind.Int64);

        public static TypeResolution Float32 { get; } = new ScalarBuiltinType(BuiltinTypeKind.Float32);

        public static TypeResolution Float64 { get; } = new ScalarBuiltinType(BuiltinTypeKind.Float64);

        public static TypeResolution Char { get; } = new ScalarBuiltinType(BuiltinTypeKind.Char);

        public static TypeResolution String { get; } = new ScalarBuiltinType(BuiltinTypeKind.String);
    }

    public static class BuiltinTypeNames
    {
        public const string VectorPrefix = "vec";

        public const string MatrixPrefix = "mat";

        public const string Bool = "bool";

        public const string UInt8 = "u8";

        public const string Int8 = "i8";

        public const string UInt16 = "u16";

        public const string Int16 = "i16";

        public const string UInt32 = "u32";

        public const string Int32 = "i32";

        public const string UInt64 = "u64";

        public const string Int64 = "i64";

        public const string Float32 = "f32";

        public const string Float64 = "f64";

        public const string Char = "char";

        public const string String = "string";
    }
}
