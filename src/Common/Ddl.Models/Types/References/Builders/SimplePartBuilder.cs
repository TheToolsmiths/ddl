using TheToolsmiths.Ddl.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Models.Types.References.Builders
{
    public class SimplePartBuilder : TypeReferencePartBuilder
    {
        public SimplePartBuilder(string name)
            : base(name)
        {
        }

        public override TypeReferencePathPart Build()
        {
            return new SimpleReferencePathPart(this.Name);
        }
    }
}
