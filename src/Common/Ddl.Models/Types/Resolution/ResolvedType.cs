using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Package;
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

        public ContentUnitId ContentUnitId { get; }

        public PackageId PackageId { get; }

        public EntityReference EntityReference { get; }
    }
}
