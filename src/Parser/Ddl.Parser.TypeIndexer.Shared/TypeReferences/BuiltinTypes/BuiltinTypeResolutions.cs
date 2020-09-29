using TheToolsmiths.Ddl.Models.Types.Resolution;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences.BuiltinTypes
{
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
}