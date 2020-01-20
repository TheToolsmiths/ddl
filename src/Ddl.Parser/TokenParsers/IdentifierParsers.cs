using System;
using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.TokenParsers
{
    public static class IdentifierParsers
    {
        public static Identifier CreateIdentifier(ITerminalNode identifierNode)
        {
            if (identifierNode == null)
            {
                throw new ArgumentNullException(nameof(identifierNode));
            }

            string text = identifierNode.GetText();

            return new Identifier(text);
        }
    }
}
