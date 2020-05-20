using Ddl.Resolve.Models.FirstPhase.ImportPaths;
using TheToolsmiths.Ddl.Parser.Models.Types.Namespaces;
using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace Ddl.Resolve.Models.TypeResolve
{
    public abstract class ResolvedType
    {
        public abstract ResolvedTypeKind ResolvedKind { get; }
    }

    public class ResolvedItemType : ResolvedType
    {
        public override ResolvedTypeKind ResolvedKind => ResolvedTypeKind.ResolvedItem;
    }

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

    public class UnresolvedType : ResolvedType
    {
        public UnresolvedType(TypeIdentifierPath typePath)
        {
            this.TypePath = typePath;
        }

        public override ResolvedTypeKind ResolvedKind => ResolvedTypeKind.Unresolved;

        public TypeIdentifierPath TypePath { get; }
    }

    public enum ResolvedTypeKind
    {
        ResolvedItem,
        ResolvedImportPath,
        Unresolved
    }
}
