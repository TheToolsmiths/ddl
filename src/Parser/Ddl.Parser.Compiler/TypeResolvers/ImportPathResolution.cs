using TheToolsmiths.Ddl.Models.Build.Items.References;
using TheToolsmiths.Ddl.Models.Compiled.Types.Resolution;

namespace TheToolsmiths.Ddl.Parser.Compiler.TypeResolvers
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
