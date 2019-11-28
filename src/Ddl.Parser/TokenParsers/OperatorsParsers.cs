using System;
using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Parser.Models.Operators;

namespace TheToolsmiths.Ddl.Parser.TokenParsers
{
    public static class OperatorsParsers
    {
        public static IConditionalLogicalOperator ParseConditionalLogicalOperator(ITerminalNode node)
        {
            var opText = node.GetText();

            switch (opText)
            {
                case "||": return new OrOperator();
                case "&&": return new AndOperator();
                default:
                    throw new ArgumentOutOfRangeException(opText);
            }
        }

        public static IEqualityComparerOperator ParseEqualityComparer(ITerminalNode node)
        {
            var eqText = node.GetText();

            switch (eqText)
            {
                case "==": return new EqualityComparerOperator();
                case "!=": return new InequalityComparerOperator();
                default:
                    throw new ArgumentOutOfRangeException(eqText);
            }
        }
    }
}
