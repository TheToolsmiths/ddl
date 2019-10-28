using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class StructDefinitionVisitor : BaseVisitor<StructDefinition>
    {
        public override StructDefinition VisitDefStruct(DdlParser.DefStructContext context)
        {
            IReadOnlyList<AttributeUse> attributes;
            {
                var attrContext = context.attrUseList();

                var attributeVisitor = new AttributeUseListVisitor();

                attributes = attributeVisitor.VisitAttrUseList(attrContext);
            }

            TypeName typeName;
            {
                var typeContext = context.typeName();

                var visitor = new TypeNameVisitor();

                typeName = visitor.VisitTypeName(typeContext);
            }

            var structFields = new List<FieldDefinition>();
            {
                foreach (var fieldContext in context.structField())
                {
                    var visitor = new StructFieldVisitor();

                    var structField = visitor.VisitStructField(fieldContext);

                    structFields.Add(structField);
                }
            }

            return new StructDefinition(typeName, attributes, structFields);
        }
    }
}
