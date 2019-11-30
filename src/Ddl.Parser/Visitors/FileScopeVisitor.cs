using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FileScopeVisitor : BaseVisitor<FileScope>
    {
        public override FileScope VisitFileScope(DdlParser.FileScopeContext context)
        {
            ConditionalExpression conditionalExpression;
            {
                var expressionContext = context.conditionalExpression();

                if (expressionContext != null)
                {
                    var visitor = new ConditionalExpressionVisitor();

                    conditionalExpression = visitor.VisitConditionalExpression(expressionContext);
                }
                else
                {
                    conditionalExpression = ConditionalExpression.CreateEmpty();
                }
            }

            FileContents fileContent;
            {
                var fileContents = context.fileContents();

                if (fileContents != null)
                {
                    var visitor = new FileContentsVisitor();

                    fileContent = visitor.VisitFileContents(fileContents);
                }
                else
                {
                    fileContent = FileContents.CreateEmpty();
                }
            }

            return new FileScope(conditionalExpression, fileContent);
        }
    }
}
