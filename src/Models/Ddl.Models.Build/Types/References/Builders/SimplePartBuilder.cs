using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Models.Build.Types.References.Builders
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
