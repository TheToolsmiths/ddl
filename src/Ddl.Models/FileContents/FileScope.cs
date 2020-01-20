using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.FileContents
{
    public class FileScope : IFileContentItem
    {
        public FileScope(ConditionalExpression conditionalExpression, FileContent content)
        {
            this.ConditionalExpression = conditionalExpression;
            this.Content = content;
        }

        public FileContentItemType ItemType => FileContentItemType.FileScope;

        public ConditionalExpression ConditionalExpression { get; }

        public FileContent Content { get; }
    }
}
