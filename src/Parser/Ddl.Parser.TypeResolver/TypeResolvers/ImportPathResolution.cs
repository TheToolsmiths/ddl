using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Types.Resolution;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    public class ImportPathResolution
    {
        public ImportPathResolution(TypeResolution typeResolution, ItemReference importPathReference)
        {
            this.TypeResolution = typeResolution;
            this.ImportPathReference = importPathReference;
        }

        public TypeResolution TypeResolution { get; }

        public ItemReference ImportPathReference { get; }
    }
}
