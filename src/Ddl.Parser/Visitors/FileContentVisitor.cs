using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FileContentVisitor : BaseVisitor<FileContent>
    {
        public override FileContent VisitFileContents(DdlParser.FileContentsContext context)
        {
            var content = new List<IFileContentItem>();

            foreach (var fileContentContext in context.fileContent())
            {
                var visitor = new FileContentItemVisitor();

                var contentItem = visitor.VisitFileContent(fileContentContext);

                content.Add(contentItem);
            }

            return new FileContent(content);
        }
    }
}
