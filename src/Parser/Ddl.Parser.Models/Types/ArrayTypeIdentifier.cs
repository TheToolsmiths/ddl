using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.Arrays;

namespace TheToolsmiths.Ddl.Parser.Models.Types
{
    public class ArrayTypeIdentifier : ITypeIdentifier
    {
        public ArrayTypeIdentifier(IQualifiedTypeIdentifier typeIdentifier, IReadOnlyList<ArraySize> sizes)
        {
            this.TypeIdentifier = typeIdentifier;
            this.Sizes = sizes;
        }

        public TypeIdentifierKind Kind => TypeIdentifierKind.ArrayType;

        public IReadOnlyList<ArraySize> Sizes { get; }

        public IQualifiedTypeIdentifier TypeIdentifier { get; }


        public override string ToString()
        {
            return $"{this.TypeIdentifier}{string.Concat(this.Sizes)}";
        }
    }
}
