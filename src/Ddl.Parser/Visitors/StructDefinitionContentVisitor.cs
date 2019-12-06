using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Structs;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class StructDefinitionContentVisitor : BaseVisitor<StructDefinitionContent>
    {
        public override StructDefinitionContent VisitDefStructContents(
            DdlParser.DefStructContentsContext context)
        {
            var items = new List<IStructDefinitionItem>();

            {
                foreach (var fieldContext in context.structField())
                {
                    var visitor = new StructFieldVisitor();

                    var structField = visitor.VisitStructField(fieldContext);

                    items.Add(structField);
                }
            }

            {
                var structScopeContext = context.structScope();

                if (structScopeContext != null)
                {
                    var visitor = new StructScopeVisitor();

                    var structScope = visitor.VisitStructScope(structScopeContext);

                    items.Add(structScope);
                }
            }

            {
                var defStructContentsContext = context.defStructContents();

                if (defStructContentsContext != null)
                {
                    var visitor = new StructDefinitionContentVisitor();

                    var contents = visitor.VisitDefStructContents(defStructContentsContext);

                    items.AddRange(contents.Items);
                }
            }

            return new StructDefinitionContent(items);
        }
    }
}
