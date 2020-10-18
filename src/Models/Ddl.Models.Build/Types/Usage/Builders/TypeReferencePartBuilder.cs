using TheToolsmiths.Ddl.Models.Build.Types.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Types.Usage.Builders
{
    public abstract class TypeReferencePartBuilder
    {
        protected TypeReferencePartBuilder(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public abstract TypePathPart Build();
    }
}
