using Microsoft.VisualStudio.TestTools.UnitTesting;

using Antlr4.Runtime;
using TheToolsmiths.Ddl.Parser.Visitors;

namespace TheToolsmiths.Ddl.Parser.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFileContents()
        {
            var content = "def struct Foo {}";

            var inputStream = CharStreams.fromstring(content);
            var lexer = new DdlLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new DdlParser(commonTokenStream)
            {
                BuildParseTree = true
            };

            var visitor = new FileContentsVisitor();

            var fileContents = parser.fileContents();

            var structDefinition = visitor.VisitFileContents(fileContents);
        }
    }

    public class Foo
    {
    }
}
