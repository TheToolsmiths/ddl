using TheToolsmiths.Ddl.Models.Compiled.Items.References;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Resolution
{
    public class ResolvedType : TypeResolution
    {
        public ResolvedType(EntityReference entityReference)
            : base(TypeResolutionKind.ResolvedType)
        {
            this.EntityReference = entityReference;
        }

        public EntityReference EntityReference { get; }
    }
}
