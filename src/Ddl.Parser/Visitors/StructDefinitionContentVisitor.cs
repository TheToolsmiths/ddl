using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class StructDefinitionContentVisitor : BaseVisitor<StructDefinitionContent>
    {
        public override StructDefinitionContent VisitDefStructContents(
            DdlParser.DefStructContentsContext context)
        {
            var fields = new List<FieldDefinition>();
            {
                foreach (var fieldContext in context.structField())
                {
                    var visitor = new StructFieldVisitor();

                    var structField = visitor.VisitStructField(fieldContext);

                    fields.Add(structField);
                }
            }

            var scopes = new List<StructScope>();
            {
                foreach (var fieldContext in context.structScope())
                {
                    var visitor = new StructScopeVisitor();

                    var structScope = visitor.VisitStructScope(fieldContext);

                    scopes.Add(structScope);
                }
            }

            return new StructDefinitionContent(fields, scopes);
        }
    }
}
