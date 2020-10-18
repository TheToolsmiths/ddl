
using TheToolsmiths.Ddl.Models.Compiled.Types.Resolution;

namespace TheToolsmiths.Ddl.Parser.Compiler.TypeResolvers.BuiltinTypes
{
    public static class BuiltinTypeResolutions
    {
        public static TypeResolution Bool { get; } = new ResolvedScalarType(BuiltinTypeKind.Bool);

        public static TypeResolution UInt8 { get; } = new ResolvedScalarType(BuiltinTypeKind.UInt8);

        public static TypeResolution Int8 { get; } = new ResolvedScalarType(BuiltinTypeKind.Int8);

        public static TypeResolution UInt16 { get; } = new ResolvedScalarType(BuiltinTypeKind.UInt16);

        public static TypeResolution Int16 { get; } = new ResolvedScalarType(BuiltinTypeKind.Int16);

        public static TypeResolution UInt32 { get; } = new ResolvedScalarType(BuiltinTypeKind.UInt32);

        public static TypeResolution Int32 { get; } = new ResolvedScalarType(BuiltinTypeKind.Int32);

        public static TypeResolution UInt64 { get; } = new ResolvedScalarType(BuiltinTypeKind.UInt64);

        public static TypeResolution Int64 { get; } = new ResolvedScalarType(BuiltinTypeKind.Int64);

        public static TypeResolution Float32 { get; } = new ResolvedScalarType(BuiltinTypeKind.Float32);

        public static TypeResolution Float64 { get; } = new ResolvedScalarType(BuiltinTypeKind.Float64);

        public static TypeResolution Char { get; } = new ResolvedScalarType(BuiltinTypeKind.Char);

        public static TypeResolution String { get; } = new ResolvedScalarType(BuiltinTypeKind.String);
    }
}
