using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.References
{
    public class SimpleReferencePathPart : TypeReferencePathPart
    {
        public SimpleReferencePathPart(string name)
            : base(name)
        {
        }

        public override TypeNameKind PartKind => TypeNameKind.Simple;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
