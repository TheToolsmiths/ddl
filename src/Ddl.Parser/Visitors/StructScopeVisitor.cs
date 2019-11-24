using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class StructScopeVisitor : BaseVisitor<StructScope>
    {
        public override StructScope VisitStructScope(DdlParser.StructScopeContext context)
        {
            StructDefinitionContent structContent;
            {
                var defStructContents = context.defStructContents();

                if (defStructContents != null)
                {
                    var visitor = new StructDefinitionContentVisitor();

                    structContent = visitor.VisitDefStructContents(defStructContents);
                }
                else
                {
                    structContent = StructDefinitionContent.CreateEmpty();
                }
            }

            return new StructScope(structContent);
        }
    }
}
