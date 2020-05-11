namespace Ddl.Resolve.Models.FirstPhase.ImportPaths
{
    public class ResolvedImportRoot
    {
        private ResolvedImportRoot(ResolvedImportItem childItem, bool isRooted)
        {
            this.ChildItem = childItem;
            this.IsRooted = isRooted;
        }

        public ResolvedImportItem ChildItem { get; }

        public bool IsRooted { get; }

        public static ResolvedImportRoot CreateRooted(ResolvedImportItem path)
        {
            return new ResolvedImportRoot(path, isRooted: true);
        }

        public static ResolvedImportRoot CreateNonRooted(ResolvedImportItem path)
        {
            return new ResolvedImportRoot(path, isRooted: false);
        }
    }
}
