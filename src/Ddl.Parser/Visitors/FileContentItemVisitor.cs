using System;
using TheToolsmiths.Ddl.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FileContentItemVisitor : BaseVisitor<IFileContentItem>
    {
        public override IFileContentItem VisitFileContent(DdlParser.FileContentContext context)
        {
            {
                var structContext = context.defStruct();

                if (structContext != null)
                {
                    var visitor = new StructDefinitionVisitor();

                    return visitor.VisitDefStruct(structContext);
                }
            }

            {
                var fileScopeContext = context.fileScope();

                if (fileScopeContext != null)
                {
                    var visitor = new FileScopeVisitor();

                    return visitor.VisitFileScope(fileScopeContext);
                }
            }

            throw new NotImplementedException();
        }
    }
}
