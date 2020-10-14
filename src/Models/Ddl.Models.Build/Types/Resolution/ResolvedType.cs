using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Package;
using TheToolsmiths.Ddl.Models.Build.References.ItemReferences;

namespace TheToolsmiths.Ddl.Models.Build.Types.Resolution
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
