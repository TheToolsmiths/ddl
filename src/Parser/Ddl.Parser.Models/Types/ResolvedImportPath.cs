using TheToolsmiths.Ddl.Parser.Models.ImportPaths;
using TheToolsmiths.Ddl.Parser.Models.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.Models.TypePaths.References;

namespace TheToolsmiths.Ddl.Parser.Models.Types
{
    public class ResolvedImportPath : ResolvedTypePart
    {
        public ResolvedImportPath(ResolvedImportRoot importRoot, TypeReferencePath lookupPath, NamespacePath scopeNamespace)
        {
            this.ImportRoot = importRoot;
            this.LookupPath = lookupPath;
            this.ScopeNamespace = scopeNamespace;
        }

        public override ResolvedTypePartKind ResolvedKind => ResolvedTypePartKind.ResolvedImportPath;

        public ResolvedImportRoot ImportRoot { get; }

        public TypeReferencePath LookupPath { get; }

        public NamespacePath ScopeNamespace { get; }
    }
}
