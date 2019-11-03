using System;
using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Utils
{
    public static class LiteralUtils
    {
        public static LiteralInitialization CreateLiteralInitialization(ITerminalNode literalNode)
        {
            if (literalNode == null)
            {
                throw new ArgumentNullException();
            }

            var text = literalNode.GetText();

            return new LiteralInitialization(text);
        }
    }
}
