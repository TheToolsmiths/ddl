using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Types.Names.Qualified
{
    public abstract class QualifiedTypeName
    {
        protected QualifiedTypeName(RootNamespacePath namespacePath)
        {
            this.NamespacePath = namespacePath;
        }

        public RootNamespacePath NamespacePath { get; }

        public abstract override string ToString();
    }
}
