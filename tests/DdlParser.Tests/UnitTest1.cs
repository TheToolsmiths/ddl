using Microsoft.VisualStudio.TestTools.UnitTesting;

using Antlr4.Runtime;

namespace TheToolsmiths.Ddl.Parser.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDefStruct()
        {
            var content = "def struct Foo {}";

            var inputStream = CharStreams.fromstring(content);
            var lexer = new DdlLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new DdlParser(commonTokenStream)
            {
                BuildParseTree = true
            };

            var bar = TreeUtils.PrintSyntaxTree(parser, parser.defStruct());
        }
    }
}
