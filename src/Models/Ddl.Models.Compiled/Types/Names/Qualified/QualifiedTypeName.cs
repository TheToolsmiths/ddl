using TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Names.Qualified
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
