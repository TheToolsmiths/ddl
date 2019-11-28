using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class FileScope
    {
        public FileScope(ConditionalExpression conditionalExpression, FileContents contents)
        {
            ConditionalExpression = conditionalExpression;
            Contents = contents;
        }

        public ConditionalExpression ConditionalExpression { get; }

        public FileContents Contents { get; }
    }
}
