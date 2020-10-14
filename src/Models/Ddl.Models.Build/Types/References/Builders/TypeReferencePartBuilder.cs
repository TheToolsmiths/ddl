using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Models.Build.Types.References.Builders
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
