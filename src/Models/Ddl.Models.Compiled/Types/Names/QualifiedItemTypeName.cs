using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Names
{
    public class QualifiedItemTypeName : QualifiedTypeName
    {
        public QualifiedItemTypeName(ItemTypeName itemTypeName, QualifiedNamespacePath namespacePath)
            : base(namespacePath)
        {
            this.ItemTypeName = itemTypeName;
        }

        public TypeName ItemTypeName { get; }

        public override string ToString()
        {
            if (this.NamespacePath.IsEmpty)
            {
                return $"::{this.ItemTypeName}";
            }

            return $"{this.NamespacePath}::{this.ItemTypeName}";
        }
    }
}
