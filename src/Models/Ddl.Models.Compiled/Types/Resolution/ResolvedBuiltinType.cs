namespace TheToolsmiths.Ddl.Models.Compiled.Types.Resolution
{
    public abstract class ResolvedBuiltinType : TypeResolution
    {
        protected ResolvedBuiltinType(BuiltinTypeKind typeKind, BuiltinTypeDimension typeDimension)
            : base(TypeResolutionKind.Builtin)
        {
            this.TypeKind = typeKind;
            this.TypeDimension = typeDimension;
        }

        public BuiltinTypeKind TypeKind { get; }

        public BuiltinTypeDimension TypeDimension { get; }
    }

    public class ResolvedScalarType : ResolvedBuiltinType
    {
        public ResolvedScalarType(BuiltinTypeKind typeKind)
            : base(typeKind, BuiltinTypeDimension.Scalar)
        {
        }
    }

    public class ResolvedVectorType : ResolvedBuiltinType
    {
        public ResolvedVectorType(BuiltinTypeKind typeKind, int vectorSize)
            : base(typeKind, BuiltinTypeDimension.Vector)
        {
            this.VectorSize = vectorSize;
        }

        public int VectorSize { get; }
    }

    public class ResolvedMatrixType : ResolvedBuiltinType
    {
        public ResolvedMatrixType(BuiltinTypeKind typeKind, int rowSize, int columnSize)
            : base(typeKind, BuiltinTypeDimension.Matrix)
        {
            this.RowSize = rowSize;
            this.ColumnSize = columnSize;
        }

        public int RowSize { get; }

        public int ColumnSize { get; }
    }

    public enum BuiltinTypeKind
    {
        Bool,
        UInt8,
        Int8,
        UInt16,
        Int16,
        UInt32,
        Int32,
        UInt64,
        Int64,
        Float32,
        Float64,
        Char,
        String
    }

    public enum BuiltinTypeDimension
    {
        Scalar,
        Vector,
        Matrix
    }
}
