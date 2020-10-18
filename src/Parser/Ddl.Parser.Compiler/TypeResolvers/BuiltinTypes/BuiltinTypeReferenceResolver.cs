using System;
using System.Globalization;
using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Models.Compiled.Types.Resolution;
using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Parser.Compiler.TypeResolvers.BuiltinTypes
{
    public class BuiltinTypeReferenceResolver
    {
        // TODO: Uncomment

        public bool TryResolveBuiltinType<T>(IPath<T> typePath, out TypeResolution typeResolution)
            where T : IPathPart
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

            ref readonly var initialPart = ref typePath.PathParts.AsSpan()[0];

            // We don't have generic builtin types for now
            if (initialPart.PartKind == PathPartKind.Generic)
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
            if (initialPart.Name.StartsWith(BuiltinTypeNames.MatrixPrefix, StringComparison.Ordinal))
            {
                if (this.TryResolveMatrixType(typePath, out typeResolution))
                {
                    return true;
                }
            }

            typeResolution = TypeResolution.Unresolved;
            return false;
        }

        private bool TryResolveVectorType<T>(IPath<T> typePath, out TypeResolution typeResolution)
            where T : IPathPart
        {
            if (typePath.PathParts.Length != 2)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            ref readonly var vectorPart = ref typePath.PathParts.AsSpan()[0];

            ref readonly var typePart = ref typePath.PathParts.AsSpan()[1];

            if (vectorPart.PartKind == PathPartKind.Generic || vectorPart.PartKind == PathPartKind.Generic)
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

            typeResolution = new ResolvedVectorType(builtinType, vectorSize);
            return true;
        }

        private bool TryResolveMatrixType<T>(IPath<T> typePath, out TypeResolution typeResolution)
            where T : IPathPart
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
}
