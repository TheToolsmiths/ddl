using TheToolsmiths.Ddl.Models.Build.Items.References;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Models.Build.Types.References
{
    public abstract class EntityTypeReference
    {
        protected EntityTypeReference(RootNamespacePath namespacePath)
        {
            this.NamespacePath = namespacePath;
        }

        public abstract EntityReference EntityReference { get; }

        public abstract TypeName EntityTypeName { get; }

        public RootNamespacePath NamespacePath { get; }

        public abstract override string ToString();
    }
}
