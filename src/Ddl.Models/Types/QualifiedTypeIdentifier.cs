using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Types
{
    public class QualifiedTypeIdentifier : IQualifiedTypeIdentifier
    {
        public QualifiedTypeIdentifier(Identifier typeName)
        {
            this.Name = typeName;
            this.NamespacePath = NamespacePath.Empty;
        }

        public QualifiedTypeIdentifier(Identifier typeName, NamespacePath namespacePath)
        {
            this.Name = typeName;
            this.NamespacePath = namespacePath;
        }

        public Identifier Name { get; }

        public NamespacePath NamespacePath { get; }

        public TypeIdentifierKind Kind => TypeIdentifierKind.QualifiedType;

        public QualifiedTypeIdentifierKind QualifiedKind => QualifiedTypeIdentifierKind.QualifiedType;

        public override string ToString()
        {
            if (this.NamespacePath.IsEmpty)
            {
                return this.Name.ToString();
            }

            return $"{this.NamespacePath}{TypeConstants.TypeSeparator}{this.Name}";
        }

        public static QualifiedTypeIdentifier BuildFromIdentifierList(IReadOnlyList<Identifier> identifiers)
        {
            var (namespacePath, name) = GenericTypeBuilderHelper.SplitNamespaceAndIdentifier(identifiers, false);

            return new QualifiedTypeIdentifier(name, namespacePath);
        }

        public static QualifiedTypeIdentifier BuildRootedFromIdentifierList(IReadOnlyList<Identifier> identifiers)
        {
            var (namespacePath, name) = GenericTypeBuilderHelper.SplitNamespaceAndIdentifier(identifiers, true);

            return new QualifiedTypeIdentifier(name, namespacePath);
        }
    }
}
