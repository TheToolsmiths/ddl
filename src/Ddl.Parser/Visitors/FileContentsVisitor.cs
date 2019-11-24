using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FileContentsVisitor : BaseVisitor<FileContents>
    {
        public override FileContents VisitFileContents(DdlParser.FileContentsContext context)
        {
            var structDefinitions = new List<StructDefinition>();
            {
                foreach (var structContext in context.defStruct())
                {
                    var visitor = new StructDefinitionVisitor();

                    var structDefinition = visitor.VisitDefStruct(structContext);

                    structDefinitions.Add(structDefinition);
                }
            }

            var fileScopes = new List<FileScope>();
            {
                foreach (var fileScopeContext in context.fileScope())
                {
                    var visitor = new FileScopeVisitor();

                    var fileScope = visitor.VisitFileScope(fileScopeContext);

                    fileScopes.Add(fileScope);
                }
            }

            return new FileContents(fileScopes, structDefinitions);
        }
    }
}
