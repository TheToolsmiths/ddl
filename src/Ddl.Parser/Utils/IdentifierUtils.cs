﻿using System;
using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Utils
{
    public static class IdentifierUtils
    {
        public static Identifier CreateIdentifier(ITerminalNode identifierNode)
        {
            if (identifierNode == null)
            {
                throw new ArgumentNullException();
            }

            var text = identifierNode.GetText();

            return new Identifier(text);
        }
    }
}
