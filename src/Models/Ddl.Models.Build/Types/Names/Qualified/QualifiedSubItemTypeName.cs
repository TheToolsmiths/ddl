using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified
{
    public class QualifiedSubItemTypeName : QualifiedTypeName
    {
        public QualifiedSubItemTypeName(
            TypedSubItemName subItemName,
            RootNamespacePath namespacePath)
            : base(namespacePath)
        {
            this.SubItemName = subItemName;
        }

        public TypedSubItemName SubItemName { get; }

        public override string ToString()
        {
            if (this.NamespacePath.IsEmpty
                && this.NamespacePath.IsRooted)
            {
                return $"::{this.SubItemName}";
            }

            return $"{this.NamespacePath}::{this.SubItemName}";
        }
    }
}
