using TheToolsmiths.Ddl.Parser.Models.ImportPaths;

namespace TheToolsmiths.Ddl.Parser.Build.Models.ImportPaths
{
    public class FirstPhaseResolvedImportPath
    {
        public FirstPhaseResolvedImportPath(ResolvedImportRoot importRoot, string aliasIdentifier)
        {
            this.ImportRoot = importRoot;
            this.Alias = aliasIdentifier;
        }

        public ResolvedImportRoot ImportRoot { get; }

        public string Alias { get; }

        public override string ToString()
        {
            return this.ImportRoot.ToString()!;
        }
    }
}
