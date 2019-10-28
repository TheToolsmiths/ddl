using System;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FileContentsVisitor : BaseVisitor<FileContents>
    {
        public override FileContents VisitFileContents(DdlParser.FileContentsContext context)
        {
            var structDefinitions = new List<StructDefinition>();

            foreach (var structContext in context.defStruct())
            {
                var visitor = new StructDefinitionVisitor();

                var structDefinition = visitor.VisitDefStruct(structContext);

                structDefinitions.Add(structDefinition);
            }

            return new FileContents(structDefinitions);
        }
    }
}
