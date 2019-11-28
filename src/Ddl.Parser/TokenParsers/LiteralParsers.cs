using Antlr4.Runtime.Tree;

namespace TheToolsmiths.Ddl.Parser.TokenParsers
{
    public static class LiteralParsers
    {
        public static bool ParseBooleanValue(ITerminalNode node)
        {
            var boolText = node.GetText();

            return bool.Parse(boolText);
        }

        public static string ParseStringValue(ITerminalNode node)
        {
            return node.GetText();
        }
    }
}
