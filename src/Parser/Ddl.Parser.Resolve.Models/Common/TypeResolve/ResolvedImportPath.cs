using Ddl.Parser.Resolve.Models.FirstPhase.ImportPaths;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Namespaces;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths;

namespace Ddl.Parser.Resolve.Models.Common.TypeResolve
{
    public class ResolvedImportPath : ResolvedType
    {
        public ResolvedImportPath(ResolvedImportRoot importRoot, TypeReferencePath lookupPath, NamespacePath scopeNamespace)
        {
            this.ImportRoot = importRoot;
            this.LookupPath = lookupPath;
            this.ScopeNamespace = scopeNamespace;
        }

        public override ResolvedTypeKind ResolvedKind => ResolvedTypeKind.ResolvedImportPath;

        public ResolvedImportRoot ImportRoot { get; }

        public TypeReferencePath LookupPath { get; }

        public NamespacePath ScopeNamespace { get; }
    }
}