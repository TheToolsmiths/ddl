using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Models.Types.Resolution
{
    public class MatchImportResolution : TypeResolution
    {
        public MatchImportResolution(
            ImportPath importPath,
            TypeReferencePath referencePath,
            NamespacePath scopeNamespace)
            : base(TypeResolutionKind.MatchImport)
        {
            this.ImportPath = importPath;
            this.ReferencePath = referencePath;
            this.ScopeNamespace = scopeNamespace;
        }

        public ImportPath ImportPath { get; }

        public TypeReferencePath ReferencePath { get; }

        public NamespacePath ScopeNamespace { get; }
    }
}
