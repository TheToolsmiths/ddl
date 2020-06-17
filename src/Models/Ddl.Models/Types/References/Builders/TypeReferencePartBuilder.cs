using TheToolsmiths.Ddl.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Models.Types.References.Builders
{
    public abstract class TypeReferencePartBuilder
    {
        public TypeReferencePartBuilder(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public abstract TypeReferencePathPart Build();
    }
}
