using TheToolsmiths.Ddl.Parser.Models.Structs;

namespace Ddl.Parser.Resolve.Models.FirstPhase.Items.Content
{
    public class StructDefinitionResolvedContent : FirstPhaseResolvedItemContent
    {
        public StructDefinitionResolvedContent(StructDefinitionContent content)
            : base(FirstPhaseResolvedItemType.StructDeclaration)
        {
            this.Content = content;
        }

        public StructDefinitionContent Content { get; }
    }
}
