namespace TheToolsmiths.Ddl.Models
{
    public class TypeIdentifier
    {
        public TypeIdentifier(TypeName name)
        {
            Name = name;
            this.Namespace = NamespaceIdentifier.Empty;
        }
        public TypeIdentifier(TypeName name, NamespaceIdentifier namespaceIdentifier)
        {
            Name = name;
            this.Namespace = namespaceIdentifier;
        }

        public TypeName Name { get; }

        public NamespaceIdentifier Namespace { get; }
    }
}
