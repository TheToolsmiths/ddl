using System.Collections.Generic;

using TheToolsmiths.Ddl.Parser.Ast.Models.Arrays;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers
{
    public class ArrayTypeIdentifier : ITypeIdentifier, IReferenceableTypeIdentifier, IGenericParameterTypeIdentifier, IModifiableTypeIdentifier
    {
        public ArrayTypeIdentifier(QualifiedTypeIdentifier typeIdentifier, IReadOnlyList<ArraySize> sizes)
        {
            this.TypeIdentifier = typeIdentifier;
            this.Sizes = sizes;
        }

        public IReadOnlyList<ArraySize> Sizes { get; }

        public QualifiedTypeIdentifier TypeIdentifier { get; }

        public override string ToString()
        {
            return $"{this.TypeIdentifier}{string.Concat(this.Sizes)}";
        }
    }
}
