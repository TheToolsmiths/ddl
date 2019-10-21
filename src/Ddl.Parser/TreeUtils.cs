using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace TheToolsmiths.Ddl.Parser
{
    public static class TreeUtils
    {
        public static string PrintSyntaxTree(Antlr4.Runtime.Parser parser, IParseTree root)
        {
            var buf = new StringBuilder();
            RecursivePrint(root, buf, 0, parser.RuleNames.ToList());
            return buf.ToString();
        }

        private static void RecursivePrint(IParseTree tree, StringBuilder buf, int offset, List<string> ruleNames)
        {
            for (int i = 0; i < offset; i++)
            {
                buf.Append("\t");
            }

            buf.AppendLine(Trees.GetNodeText(tree, ruleNames));

            if (tree is ParserRuleContext prc)
            {
                if (prc.children != null)
                {
                    foreach (var child in prc.children)
                    {
                        RecursivePrint(child, buf, offset + 1, ruleNames);
                    }
                }
            }
        }
    }
}
