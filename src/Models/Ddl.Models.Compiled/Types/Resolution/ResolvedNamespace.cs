using TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Resolution
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
