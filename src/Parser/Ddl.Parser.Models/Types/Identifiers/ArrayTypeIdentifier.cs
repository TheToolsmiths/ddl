using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.Arrays;

namespace TheToolsmiths.Ddl.Parser.Models.Types.Identifiers
{
    public class ArrayTypeIdentifier : ITypeIdentifier
    {
        public ArrayTypeIdentifier(QualifiedTypeIdentifier typeIdentifier, IReadOnlyList<ArraySize> sizes)
        {
            this.TypeIdentifier = typeIdentifier;
            this.Sizes = sizes;
        }

        public IReadOnlyList<ArraySize> Sizes { get; }

        public QualifiedTypeIdentifier TypeIdentifier { get; }

        public TypeIdentifierKind Kind => TypeIdentifierKind.ArrayType;

        public override string ToString()
        {
            return $"{this.TypeIdentifier}{string.Concat(this.Sizes)}";
        }
    }
}
