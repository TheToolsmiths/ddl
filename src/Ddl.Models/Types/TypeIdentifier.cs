using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Types
{
    public class TypeIdentifier
    {
        public TypeIdentifier(TypeName name)
        {
            this.Name = name;
            this.Namespace = NamespaceIdentifier.Empty;
        }
        public TypeIdentifier(TypeName name, NamespaceIdentifier namespaceIdentifier)
        {
            this.Name = name;
            this.Namespace = namespaceIdentifier;
        }

        public TypeName Name { get; }

        public NamespaceIdentifier Namespace { get; }

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
