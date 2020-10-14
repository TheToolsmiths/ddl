using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.Package;
using TheToolsmiths.Ddl.Models.Compiled.References.ItemReferences;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Resolution
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
