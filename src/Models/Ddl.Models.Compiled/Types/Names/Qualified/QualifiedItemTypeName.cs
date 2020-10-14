using TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Names.Qualified
{
    public class QualifiedItemTypeName : QualifiedTypeName
    {
        public QualifiedItemTypeName(TypedItemName itemName, RootNamespacePath namespacePath)
            : base(namespacePath)
        {
            this.ItemName = itemName;
        }

        public TypedItemName ItemName { get; }

        public override string ToString()
        {
            if (this.NamespacePath.IsEmpty
            && this.NamespacePath.IsRooted)
            {
                return $"::{this.ItemName}";
            }

            return $"{this.NamespacePath}::{this.ItemName}";
        }
    }
}
