using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types
{
    public class SimpleTypeIdentifier : IQualifiedTypeIdentifier
    {
        private SimpleTypeIdentifier(Identifier typeName, NamespacePath namespacePath)
        {
            this.Name = typeName;
            this.NamespacePath = namespacePath;
        }

        public Identifier Name { get; }

        public NamespacePath NamespacePath { get; }

        public bool IsGeneric => false;

        public TypeIdentifierKind Kind => TypeIdentifierKind.QualifiedType;

        public QualifiedTypeIdentifierKind QualifiedKind => QualifiedTypeIdentifierKind.SimpleType;

        public override string ToString()
        {
            if (this.NamespacePath.IsEmpty)
            {
                return this.Name.ToString();
            }

            return $"{this.NamespacePath}{TypeConstants.TypeSeparator}{this.Name}";
        }

        public static SimpleTypeIdentifier BuildFromIdentifierList(IReadOnlyList<Identifier> identifiers)
        {
            var (namespacePath, name) = GenericTypeBuilderHelper.SplitNamespaceAndIdentifier(identifiers, false);

            return new SimpleTypeIdentifier(name, namespacePath);
        }

        public static SimpleTypeIdentifier BuildRootedFromIdentifierList(IReadOnlyList<Identifier> identifiers)
        {
            var (namespacePath, name) = GenericTypeBuilderHelper.SplitNamespaceAndIdentifier(identifiers, true);

            return new SimpleTypeIdentifier(name, namespacePath);
        }
    }
}
