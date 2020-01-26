using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Types
{
    public class TypeIdentifier
    {
        public TypeIdentifier(ITypeName typeName)
        {
            this.Name = typeName;
            this.Namespace = NamespacePath.Empty;
        }
        public TypeIdentifier(ITypeName typeName, NamespacePath namespacePath)
        {
            this.Name = typeName;
            this.Namespace = namespacePath;
        }

        public ITypeName Name { get; }

        public NamespacePath Namespace { get; }

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
