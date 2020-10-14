using System;

namespace TheToolsmiths.Ddl.Models.Ast.Types.Identifiers
{
    public static class TypeIdentifierHelpers
    {
        public static QualifiedTypeIdentifier GetQualifiedType(ITypeIdentifier typeIdentifier)
        {
            return typeIdentifier switch
            {
                ArrayTypeIdentifier identifier => GetQualifiedType(identifier),
                ConstantTypeIdentifier identifier => GetQualifiedType(identifier),
                QualifiedTypeIdentifier identifier => GetQualifiedType(identifier),
                ReferenceTypeIdentifier identifier => GetQualifiedType(identifier),
                _ => throw new ArgumentOutOfRangeException(nameof(typeIdentifier))
            };
        }

        public static QualifiedTypeIdentifier GetQualifiedType(ArrayTypeIdentifier typeIdentifier)
        {
            return GetQualifiedType(typeIdentifier.TypeIdentifier);
        }

        public static QualifiedTypeIdentifier GetQualifiedType(ConstantTypeIdentifier typeIdentifier)
        {
            return GetQualifiedType(typeIdentifier.TypeIdentifier);
        }

        public static QualifiedTypeIdentifier GetQualifiedType(QualifiedTypeIdentifier typeIdentifier)
        {
            return typeIdentifier;
        }

        public static QualifiedTypeIdentifier GetQualifiedType(ReferenceTypeIdentifier typeIdentifier)
        {
            return GetQualifiedType(typeIdentifier.TypeIdentifier);
        }
    }
}
