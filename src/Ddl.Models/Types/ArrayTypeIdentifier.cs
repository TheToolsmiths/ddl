using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Arrays;

namespace TheToolsmiths.Ddl.Models.Types
{
    public class ArrayTypeIdentifier : ITypeIdentifier
    {
        public ArrayTypeIdentifier(QualifiedTypeIdentifier typeIdentifier, IReadOnlyList<ArraySize> sizes)
        {
            this.TypeIdentifier = typeIdentifier;
            this.Sizes = sizes;
        }

        public TypeIdentifierType Type => TypeIdentifierType.ArrayType;

        public IReadOnlyList<ArraySize> Sizes { get; }


        public QualifiedTypeIdentifier TypeIdentifier { get; }


        public override string ToString()
        {
            return $"{this.TypeIdentifier}{string.Concat(this.Sizes)}";
        }
    }
}
