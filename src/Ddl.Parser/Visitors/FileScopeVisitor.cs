using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FileScopeVisitor : BaseVisitor<FileScope>
    {
        public override FileScope VisitFileScope(DdlParser.FileScopeContext context)
        {
            ConditionalExpression conditionalExpression;
            {
                var scopeHeaderContext = context.scopeHeader();

                var visitor = new ScopeHeaderVisitor();

                conditionalExpression = visitor.VisitScopeHeader(scopeHeaderContext);
            }

            FileContent fileContent;
            {
                var fileContents = context.fileContents();

                if (fileContents != null)
                {
                    var visitor = new FileContentVisitor();

                    fileContent = visitor.VisitFileContents(fileContents);
                }
                else
                {
                    fileContent = FileContent.CreateEmpty();
                }
            }

            return new FileScope(conditionalExpression, fileContent);
        }
    }
}
