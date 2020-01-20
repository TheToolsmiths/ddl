using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Utils;
using TheToolsmiths.Ddl.Parser.Visitors;

namespace TheToolsmiths.Ddl.Parser
{
    public static class DdlTextParser
    {
        public static Task<FileContent> ReadFromString(string contents)
        {
            throw new NotImplementedException();
        }

        public static Task<FileContent> ReadFromFile(string path)
        {
            return Task.Run(() =>
            {
                var parser = ParserUtils.CreateParserFromPath(path);

                var visitor = new FileContentVisitor();

                var fileContentsContext = parser.fileContents();

                var fileContents = visitor.VisitFileContents(fileContentsContext);

                return fileContents;
            });
        }
    }
}
