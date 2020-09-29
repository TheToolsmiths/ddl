using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Types.Resolution
{
    public class ResolvedNamespace : TypeResolution
    {
        public ResolvedNamespace(RootNamespacePath namespacePath)
            : base(TypeResolutionKind.Namespace)
        {
            this.NamespacePath = namespacePath;
        }

        public RootNamespacePath NamespacePath { get; }
    }
}
