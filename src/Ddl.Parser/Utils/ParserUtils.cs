using Antlr4.Runtime;

namespace TheToolsmiths.Ddl.Parser.Utils
{
    public static class ParserUtils
    {
        public static DdlParser CreateParserFromPath(string path)
        {
            var inputStream = CharStreams.fromPath(path);

            return CreateParser(inputStream);
        }

        private static DdlParser CreateParser(ICharStream stream)
        {
            var lexer = new DdlLexer(stream);
            var commonTokenStream = new CommonTokenStream(lexer);

            var parser = new DdlParser(commonTokenStream)
            {
                BuildParseTree = true,
                ErrorHandler = new BailErrorStrategy()
            };
            
            return parser;
        }
    }
}
