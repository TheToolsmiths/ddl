using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models
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
