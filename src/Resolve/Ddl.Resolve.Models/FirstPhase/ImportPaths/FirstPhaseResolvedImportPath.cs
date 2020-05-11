namespace Ddl.Resolve.Models.FirstPhase.ImportPaths
{
    public class FirstPhaseResolvedImportPath
    {
        public FirstPhaseResolvedImportPath(ResolvedImportRoot importRoot)
        {
            this.ImportRoot = importRoot;
        }

        public ResolvedImportRoot ImportRoot { get; }

    }
}
