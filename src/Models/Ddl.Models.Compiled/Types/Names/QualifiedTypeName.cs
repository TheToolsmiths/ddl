using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Names
{
    public abstract class QualifiedTypeName
    {
        protected QualifiedTypeName(QualifiedNamespacePath namespacePath)
        {
            this.NamespacePath = namespacePath;
        }

        public QualifiedNamespacePath NamespacePath { get; }

        public abstract override string ToString();
    }
}
