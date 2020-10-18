using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Paths
{
    public class ResolvedSimplePathPart : ResolvedTypePathPart
    {
        public ResolvedSimplePathPart(string name)
            : base(name)
        {
        }

        public override PathPartKind PartKind => PathPartKind.Simple;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
