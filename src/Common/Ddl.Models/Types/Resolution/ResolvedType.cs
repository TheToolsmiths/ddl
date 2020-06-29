using TheToolsmiths.Ddl.Models.References.ItemReferences;

namespace TheToolsmiths.Ddl.Models.Types.Resolution
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
