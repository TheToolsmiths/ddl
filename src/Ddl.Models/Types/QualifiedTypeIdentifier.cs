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

        public TypeIdentifierType Type => TypeIdentifierType.QualifiedType;

        public override string ToString()
        {
            if (this.Namespace.IsEmpty)
            {
                return this.Name.ToString();
            }

            return $"{this.Namespace}{TypeConstants.TypeSeparator}{this.Name}";
        }
    }
}
