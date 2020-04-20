using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Structs;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class StructScopeVisitor : BaseVisitor<StructScope>
    {
        public override StructScope VisitStructScope(DdlParser.StructScopeContext context)
        {
            ConditionalExpression conditionalExpression;
            {
                var scopeHeaderContext = context.scopeHeader();

                var visitor = new ScopeHeaderVisitor();

                conditionalExpression = visitor.VisitScopeHeader(scopeHeaderContext);
            }

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

            return new StructScope(conditionalExpression, structContent);
        }
    }
}
