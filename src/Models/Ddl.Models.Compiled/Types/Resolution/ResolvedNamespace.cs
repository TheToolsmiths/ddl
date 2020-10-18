using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Resolution
{
    public class ResolvedNamespace : TypeResolution
    {
        public ResolvedNamespace(QualifiedNamespacePath namespacePath)
            : base(TypeResolutionKind.Namespace)
        {
            this.NamespacePath = namespacePath;
        }

        public QualifiedNamespacePath NamespacePath { get; }
    }
}
