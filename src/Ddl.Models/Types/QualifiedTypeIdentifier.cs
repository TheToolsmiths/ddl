using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Types
{
    public class QualifiedTypeIdentifier : ITypeIdentifier
    {
        public QualifiedTypeIdentifier(ITypeName typeName)
        {
            this.Name = typeName;
            this.Namespace = NamespacePath.Empty;
        }

        public QualifiedTypeIdentifier(ITypeName typeName, NamespacePath namespacePath)
        {
            this.Name = typeName;
            this.Namespace = namespacePath;
        }

        public ITypeName Name { get; }

        public NamespacePath Namespace { get; }

        public TypeIdentifierKind Kind => TypeIdentifierKind.QualifiedType;

        public override string ToString()
        {
            if (this.Namespace.IsEmpty)
            {
                return this.Name.ToString();
            }

            return $"{this.Namespace}{TypeConstants.TypeSeparator}{this.Name}";
        }

        public static QualifiedTypeIdentifier BuildFromIdentifierList(IReadOnlyList<Identifier> identifiers)
        {
            return BuildFromIdentifierList(identifiers, false);
        }

        public static QualifiedTypeIdentifier BuildRootedFromIdentifierList(IReadOnlyList<Identifier> identifiers)
        {
            return BuildFromIdentifierList(identifiers, true);
        }

        private static QualifiedTypeIdentifier BuildFromIdentifierList(IReadOnlyList<Identifier> identifiers, bool isRooted)
        {
            if (identifiers == null
                || identifiers.Count == 0)
            {
                throw new ArgumentException(nameof(identifiers));
            }

            var name = identifiers[^1];

            NamespacePath namespacePath;

            if (identifiers.Count == 1)
            {
                namespacePath = NamespacePath.Empty;
            }
            else
            {
                namespacePath = NamespacePath.CreateFromIdentifiers(identifiers.GetRange(..^1));
            }

            ITypeName typeName = new SimpleTypeName(name);

            return new QualifiedTypeIdentifier(typeName, namespacePath);
        }
    }
}
