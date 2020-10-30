using TheToolsmiths.Ddl.Models.Types.Paths;

namespace TheToolsmiths.Ddl.Models.Types.Usage.Builders
{
    public class SimplePartBuilder : TypeReferencePartBuilder
    {
        public SimplePartBuilder(string name)
            : base(name)
        {
        }

        public override TypePathPart Build()
        {
            return new SimplePathPart(this.Name);
        }
    }
}
