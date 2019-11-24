namespace TheToolsmiths.Ddl.Parser.Models
{
    public class StructScope
    {
        public StructScope(StructDefinitionContent structContent)
        {
            StructContent = structContent;
        }

        public StructDefinitionContent StructContent { get; }
    }
}
