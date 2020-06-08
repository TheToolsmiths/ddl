using TheToolsmiths.Ddl.Parser.Models.References.ItemReferences;

namespace TheToolsmiths.Ddl.Parser.Models.Types.Resolved
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