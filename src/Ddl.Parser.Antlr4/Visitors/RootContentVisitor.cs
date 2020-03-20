using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FileContentVisitor : BaseVisitor<FileContent>
    {
        public override FileContent VisitFileContents(DdlParser.FileContentsContext context)
        {
            var contentListContext = context.rootContentList();

            var visitor = new RootContentListVisitor();

            var items = visitor.VisitRootContentList(contentListContext);

            return new FileContent(items);
        }
    }

    public class RootContentListVisitor : BaseVisitor<IReadOnlyList<IRootContentItem>>
    {
        public override IReadOnlyList<IRootContentItem> VisitRootContentList(DdlParser.RootContentListContext context)
        {
            var content = new List<IRootContentItem>();

            foreach (var rootContentContext in context.rootContent())
            {
                var visitor = new RootContentItemVisitor();

                var contentItem = visitor.VisitRootContent(rootContentContext);

                content.Add(contentItem);
            }

            return content;
        }
    }
}
