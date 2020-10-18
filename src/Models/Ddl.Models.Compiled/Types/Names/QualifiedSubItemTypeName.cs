using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Names
{
    public class QualifiedSubItemTypeName : QualifiedTypeName
    {
        public QualifiedSubItemTypeName(
            SubItemTypeName subItemTypeName,
            QualifiedNamespacePath namespacePath)
            : base(namespacePath)
        {
            this.SubItemTypeName = subItemTypeName;
        }

        public SubItemTypeName SubItemTypeName { get; }

        public override string ToString()
        {
            if (this.NamespacePath.IsEmpty)
            {
                return $"::{this.SubItemTypeName}";
            }

            return $"{this.NamespacePath}::{this.SubItemTypeName}";
        }
    }
}
