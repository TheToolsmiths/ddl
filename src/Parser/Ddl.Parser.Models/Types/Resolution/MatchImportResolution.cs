using TheToolsmiths.Ddl.Parser.Models.ImportPaths;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Parser.Models.Types.Resolution
{
    public class MatchImportResolution : TypeResolution
    {
        public MatchImportResolution(
            ResolvedImportRoot importRoot,
            TypeReferencePath referencePath,
            NamespacePath scopeNamespace)
            : base(TypeResolutionKind.MatchImport)
        {
            this.ImportRoot = importRoot;
            this.ReferencePath = referencePath;
            this.ScopeNamespace = scopeNamespace;
        }

        public ResolvedImportRoot ImportRoot { get; }

        public TypeReferencePath ReferencePath { get; }

        public NamespacePath ScopeNamespace { get; }
    }
}
