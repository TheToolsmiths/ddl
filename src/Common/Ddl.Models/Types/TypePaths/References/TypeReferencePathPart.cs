using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.References
{
    public abstract class TypeReferencePathPart
    {
        protected TypeReferencePathPart(string name)
        {
            this.Name = name;
        }

        public abstract TypeNameKind PartKind { get; }

        public string Name { get; }
    }
}
