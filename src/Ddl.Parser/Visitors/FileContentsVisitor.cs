using System;
using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FileContentsVisitor : BaseVisitor<FileContents>
    {
        public override FileContents Visit(IParseTree tree)
        {
            throw new NotImplementedException();
        }

        public override FileContents VisitFileContents(DdlParser.FileContentsContext context)
        {
            throw new NotImplementedException();
        }
    }
}
