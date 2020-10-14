using TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.References.Builders
{
    public abstract class TypeReferencePartBuilder
    {
        protected TypeReferencePartBuilder(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public abstract TypeReferencePathPart Build();
    }
}
