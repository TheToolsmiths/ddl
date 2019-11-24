using System;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FileScopeVisitor : BaseVisitor<FileScope>
    {
        public override FileScope VisitFileScope(DdlParser.FileScopeContext context)
        {
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

            return new FileScope(fileContent);
        }
    }
}
