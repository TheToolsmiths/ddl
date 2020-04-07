using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Types
{
    public class GenericTypeIdentifier : IQualifiedTypeIdentifier
    {
        public GenericTypeIdentifier(
            Identifier name,
            NamespacePath namespacePath,
            IReadOnlyList<ITypeIdentifier> parameters)
        {
            this.Parameters = parameters;
            this.Name = name;
            this.NamespacePath = namespacePath;
        }

        public Identifier Name { get; }

        public NamespacePath NamespacePath { get; }

        public QualifiedTypeIdentifierKind QualifiedKind => QualifiedTypeIdentifierKind.GenericType;

        public TypeIdentifierKind Kind => TypeIdentifierKind.QualifiedType;

        public IReadOnlyList<ITypeIdentifier> Parameters { get; }

        public override string ToString()
        {
            return $"{this.NamespacePath}::{this.Name}<{string.Join(',', this.Parameters.Select(p => p.ToString()))}>";
        }

        public static GenericTypeIdentifier BuildFromIdentifierList(IReadOnlyList<Identifier> identifiers,
            IReadOnlyList<ITypeIdentifier> parameters)
        {
            var (namespacePath, name) = GenericTypeBuilderHelper.SplitNamespaceAndIdentifier(identifiers, false);

            return new GenericTypeIdentifier(name, namespacePath, parameters);
        }

        public static GenericTypeIdentifier BuildRootedFromIdentifierList(IReadOnlyList<Identifier> identifiers,
            IReadOnlyList<ITypeIdentifier> parameters)
        {
            var (namespacePath, name) = GenericTypeBuilderHelper.SplitNamespaceAndIdentifier(identifiers, true);

            return new GenericTypeIdentifier(name, namespacePath, parameters);
        }
    }
}
